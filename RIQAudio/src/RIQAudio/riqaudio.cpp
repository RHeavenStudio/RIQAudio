#include <stdbool.h>

#include "riqaudio.hpp"

#define TRACELOG(level, ...) printf(__VA_ARGS__)

#define SUPPORT_FILEFORMAT_OGG
#define SUPPORT_FILEFORMAT_WAV

#if defined(SUPPORT_FILEFORMAT_OGG)
    #define STB_VORBIS_IMPLEMENTATION
    #include "miniaudio/extras/stb_vorbis.h" // Vorbis decoding
#endif

/*#if defined(SUPPORT_FILEFORMAT_WAV)
    #define DRWAV_MALLOC RL_MALLOC
    #define DRWAV_REALLOC RL_REALLOC
    #define DRWAV_FREE RL_FREE

    #define DR_WAV_IMPLEMENTATION
    #include "miniaudio/external/dr_wav.h" // WAV decoding
#endif*/

#define MINIAUDIO_IMPLEMENTATION
#include "miniaudio/miniaudio.h"


static void OnLog(void* pUserData, ma_uint32 level, const char* pMessage);
static void OnSendAudioDataToDevice(ma_device* pDevice, void* pFramesOut, const void* pFramesInput, ma_uint32 frameCount);

#define AudioBuffer riqAudioBuffer;

RIQAudio::RIQAudio()
{
    Init();
}

ma_result RIQAudio::Init(void)
{
    ma_context_config ctxConfig = ma_context_config_init();
    ma_log_callback_init(OnLog, NULL);

    ma_result result = ma_context_init(NULL, 0, &ctxConfig, &context);
    if (result != MA_SUCCESS)
    {
        TRACELOG(LOG_WARNING, "RIQAudio: Failed to initialize context!");
        return MA_ERROR;
    }

    // Initialize audio device
    ma_device_config config = ma_device_config_init(ma_device_type_playback);
    config.playback.pDeviceID = NULL;
    config.playback.format = AUDIO_DEVICE_FORMAT;
    config.playback.channels = AUDIO_DEVICE_CHANNELS;
    
    config.capture.pDeviceID = NULL;
    config.capture.format = ma_format_s16;
    config.capture.channels = 1;
    config.sampleRate = AUDIO_DEVICE_SAMPLE_RATE;

    config.dataCallback = OnSendAudioDataToDevice;
    config.pUserData = NULL;

    result = ma_device_init(&context, &config, &device);
    if (result != MA_SUCCESS)
    {
        TRACELOG(LOG_WARNING, "RIQAudio: Failed to initialize playback device!");
        return MA_ERROR;
    }

    result = ma_device_start(&device);
    if (result != MA_SUCCESS)
    {
        TRACELOG(LOG_WARNING, "RIQAudio: Failed to start playback device!");
        ma_device_uninit(&device);
        ma_context_uninit(&context);
        return MA_ERROR;
    }

    if (ma_mutex_init(&lock) != MA_SUCCESS)
    {
        TRACELOG(LOG_WARNING, "RIQAudio: Failed to create mutex for mixing!");
        ma_device_uninit(&device);
        ma_context_uninit(&context);
        return MA_ERROR;
    }

    for (int i = 0; i < 16; i++)
    {
        // Get back to this
        // AUDIO.MultiChannel.pool[i] = LoadAudioBuffer(AUDIO_DEVICE_FORMAT, AUDIO_DEVICE_CHANNELS, AUDIO.System.device.sampleRate, 0, 0);
    }

    isReady = true;

    TRACELOG(LOG_INFO, "RIQAudio: Device initialized successfully!");

    return MA_SUCCESS;
}

bool RIQAudio::IsReady()
{
    return isReady;
}

RIQAudio::~RIQAudio(void)
{
    if (isReady)
    {
        ma_mutex_uninit(&lock);
        ma_device_uninit(&device);
        ma_context_uninit(&context);

        isReady = false;

        // free(pcmBuffer);

        TRACELOG(LOG_INFO, "RIQAudio: Device closed successfully!");
    }
    else TRACELOG(LOG_WARNING, "RIQAudio: Device could not be closed, not currently initialized!");
}

static void OnSendAudioDataToDevice(ma_device* pDevice, void* pFramesOut, const void* pFramesInput, ma_uint32 frameCount)
{
    (void)pDevice;
}

// Should find out a way to link this directly to Unity's logging system
static void OnLog(void* pUserData, ma_uint32 level, const char* pMessage)
{
    // NOTE: All log messages from miniaudio are errors.
    TRACELOG(LOG_WARNING, "miniaudio: %s", pMessage);
}