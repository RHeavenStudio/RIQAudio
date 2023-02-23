#include "macros.h"

#include <stdbool.h>

#include "riqaudio.h"

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

// ================================================================================
// Types and structures definitions
// ================================================================================

struct riqAudioBuffer
{
    ma_data_converter converter;

    AudioCallback callback;
    riqAudioProcessor* processor;

    float volume;
    float pitch;
    float pan;

    bool playing;
    bool paused;
    bool looping;
    // int using;

    riqAudioBuffer* next;
    riqAudioBuffer* prev;
};

struct riqAudioProcessor
{
    AudioCallback process;
    riqAudioProcessor* next;
    riqAudioProcessor* prev;
};

typedef struct AudioData
{
    struct {
        ma_context context;         // miniaudio context data.
        ma_device device;           // miniaudio device.
        ma_mutex lock;              // miniaudio mutex lock.
        bool isReady;               // If audio device is ready.
        size_t pcmBufferSize;       // Pre-allocated buffer size.
        void* pcmBuffer;            // Pre-allocated buffer to read audio data from file/memory.
    } System;

    struct {
        riqAudioBuffer* first;      // Pointer to the first AudioBuffer in the list.
        riqAudioBuffer* last;       // Pointer to the last AudioBuffer in the list.
        int defaultSize;            // Default audio buffer size for audio streams.
    } Buffer;

    struct {
        unsigned int poolCounter;   // AudioBuffer points to pool counter.
        riqAudioBuffer* pool[16];
        unsigned int channels[16];
    } MultiChannel;

} AudioData;

// ================================================================================
// 
// ================================================================================

// Global audio context
static AudioData AUDIO = 
{
};

static void OnLog(void* pUserData, ma_uint32 level, const char* pMessage);
static void OnSendAudioDataToDevice(ma_device* pDevice, void* pFramesOut, const void* pFramesInput, ma_uint32 frameCount);

#define AudioBuffer riqAudioBuffer;

// 
void RiqInitAudioDevice(void)
{
    ma_context_config ctxConfig = ma_context_config_init();
    ma_log_callback_init(OnLog, NULL);

    ma_result result = ma_context_init(NULL, 0, &ctxConfig, &AUDIO.System.context);
    if (result != MA_SUCCESS)
    {
        TRACELOG(LOG_WARNING, "RIQAudio: Failed to initialize context!");
        return;
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

    result = ma_device_init(&AUDIO.System.context, &config, &AUDIO.System.device);
    if (result != MA_SUCCESS)
    {
        TRACELOG(LOG_WARNING, "RIQAudio: Failed to initialize playback device!");
        return;
    }

    result = ma_device_start(&AUDIO.System.device);
    if (result != MA_SUCCESS)
    {
        TRACELOG(LOG_WARNING, "RIQAudio: Failed to start playback device!");
        ma_device_uninit(&AUDIO.System.device);
        ma_context_uninit(&AUDIO.System.context);
        return;
    }

    if (ma_mutex_init(&AUDIO.System.lock) != MA_SUCCESS)
    {
        TRACELOG(LOG_WARNING, "RIQAudio: Failed to create mutex for mixing!");
        ma_device_uninit(&AUDIO.System.device);
        ma_context_uninit(&AUDIO.System.context);
        return;
    }

    for (int i = 0; i < 16; i++)
    {
        // Get back to this
        // AUDIO.MultiChannel.pool[i] = LoadAudioBuffer(AUDIO_DEVICE_FORMAT, AUDIO_DEVICE_CHANNELS, AUDIO.System.device.sampleRate, 0, 0);
    }

    AUDIO.System.isReady = true;

    TRACELOG(LOG_INFO, "RIQAudio: Device initialized successfully!");
}

bool IsRiqReady()
{
    return AUDIO.System.isReady;
}

void RiqCloseAudioDevice(void)
{
    if (AUDIO.System.isReady)
    {
        ma_mutex_uninit(&AUDIO.System.lock);
        ma_device_uninit(&AUDIO.System.device);
        ma_context_uninit(&AUDIO.System.context);

        AUDIO.System.isReady = false;

        free(AUDIO.System.pcmBuffer);

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