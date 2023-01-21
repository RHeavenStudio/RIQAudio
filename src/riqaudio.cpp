#include "riqaudio.h"

#define MA_NO_VORBIS
#define MA_NO_OPUS

#define MINIAUDIO_IMPLEMENTATION
#include "miniaudio/miniaudio.h"
#include "miniaudio/miniaudio_libvorbis.h"
// #include "miniaudio/miniaudio_libopus.h"

#include <stdlib.h>
#include <stdio.h>

static ma_result ma_decoding_backend_init__libvorbis(void* pUserData, ma_read_proc onRead, ma_seek_proc onSeek, ma_tell_proc onTell, void* pReadSeekTellUserData, const ma_decoding_backend_config* pConfig, const ma_allocation_callbacks* pAllocationCallbacks, ma_data_source** ppBackend)
{
    ma_result result;
    ma_libvorbis* pVorbis;

    (void)pUserData;

    pVorbis = (ma_libvorbis*)ma_malloc(sizeof(*pVorbis), pAllocationCallbacks);
    if (pVorbis == NULL) {
        return MA_OUT_OF_MEMORY;
    }

    result = ma_libvorbis_init(onRead, onSeek, onTell, pReadSeekTellUserData, pConfig, pAllocationCallbacks, pVorbis);
    if (result != MA_SUCCESS) {
        ma_free(pVorbis, pAllocationCallbacks);
        return result;
    }

    *ppBackend = pVorbis;

    return MA_SUCCESS;
}

static ma_result ma_decoding_backend_init_file__libvorbis(void* pUserData, const char* pFilePath, const ma_decoding_backend_config* pConfig, const ma_allocation_callbacks* pAllocationCallbacks, ma_data_source** ppBackend)
{
    ma_result result;
    ma_libvorbis* pVorbis;

    (void)pUserData;

    pVorbis = (ma_libvorbis*)ma_malloc(sizeof(*pVorbis), pAllocationCallbacks);
    if (pVorbis == NULL) {
        return MA_OUT_OF_MEMORY;
    }

    result = ma_libvorbis_init_file(pFilePath, pConfig, pAllocationCallbacks, pVorbis);
    if (result != MA_SUCCESS) {
        ma_free(pVorbis, pAllocationCallbacks);
        return result;
    }

    *ppBackend = pVorbis;

    return MA_SUCCESS;
}

static void ma_decoding_backend_uninit__libvorbis(void* pUserData, ma_data_source* pBackend, const ma_allocation_callbacks* pAllocationCallbacks)
{
    ma_libvorbis* pVorbis = (ma_libvorbis*)pBackend;

    (void)pUserData;

    ma_libvorbis_uninit(pVorbis, pAllocationCallbacks);
    ma_free(pVorbis, pAllocationCallbacks);
}

static ma_result ma_decoding_backend_get_channel_map__libvorbis(void* pUserData, ma_data_source* pBackend, ma_channel* pChannelMap, size_t channelMapCap)
{
    ma_libvorbis* pVorbis = (ma_libvorbis*)pBackend;

    (void)pUserData;

    return ma_libvorbis_get_data_format(pVorbis, NULL, NULL, NULL, pChannelMap, channelMapCap);
}

static ma_decoding_backend_vtable g_ma_decoding_backend_vtable_libvorbis =
{
    ma_decoding_backend_init__libvorbis,
    ma_decoding_backend_init_file__libvorbis,
    NULL, /* onInitFileW() */
    NULL, /* onInitMemory() */
    ma_decoding_backend_uninit__libvorbis
};

ma_result RIQAudio::init() {
    ma_result result;
    
    ma_device_config device_config = ma_device_config_init(ma_device_type_playback);
    device_config.pUserData = this;
    device_config.playback.format = ma_format_f32;
    device_config.playback.channels = 2;
    device_config.performanceProfile = ma_performance_profile_low_latency;
    if (buffer_size > 0) {
        device_config.periodSizeInMilliseconds = buffer_size;
    }

    device_config.wasapi.noAutoConvertSRC = true;

    result = ma_context_init(NULL, 0, NULL, context);

    if (result != MA_SUCCESS) {
        printf("Failed to initialize context.\n");
        return result;
    }

    result = ma_device_init(context, &device_config, device);

    if (result != MA_SUCCESS) {
        printf("Failed to initialize device.\n");
        return result;
    }

    ma_engine_config engine_config = ma_engine_config_init();
    engine_config.pDevice = device;
    engine_config.pContext = context;
    engine_config.channels = device_config.playback.channels;
    if (buffer_size > 0) {
        engine_config.periodSizeInMilliseconds = buffer_size;
    }

    ma_resource_manager_config resource_manager_config;

    /*
    Custom backend vtables
    */
    ma_decoding_backend_vtable* pCustomBackendVTables[] =
    {
        &g_ma_decoding_backend_vtable_libvorbis,
        // &g_ma_decoding_backend_vtable_libopus
    };

    /* Using custom decoding backends requires a resource manager. */
    resource_manager_config = ma_resource_manager_config_init();
    resource_manager_config.pCustomDecodingBackendUserData = NULL;
    resource_manager_config.ppCustomDecodingBackendVTables = pCustomBackendVTables;
    resource_manager_config.customDecodingBackendCount     = sizeof(pCustomBackendVTables) / sizeof(pCustomBackendVTables[0]);
    
    resource_manager_config.decodedFormat = ma_format_f32;
    resource_manager_config.decodedSampleRate = device->sampleRate;
    resource_manager_config.decodedChannels   = device->playback.channels;

    result = ma_resource_manager_init(&resource_manager_config, resource_manager);

    if (result != MA_SUCCESS) {
        printf("Failed to initialize resource manager.\n");
    }


    engine_config.pResourceManager = resource_manager;

    result = ma_engine_init(&engine_config, engine);

    if (result != MA_SUCCESS) {
        printf("Failed to initialize engine.\n");
        return result;
    }

    return MA_SUCCESS;
};

RIQAudio::RIQAudio() {
    ma_result result = init();
    if (result != MA_SUCCESS) {
        printf("Failed to initialize RIQ audio backend.\n");
    }
};

RIQAudio::~RIQAudio() {
    ma_device_uninit(device);
    ma_context_uninit(context);
    delete device;
    delete context;
    
};