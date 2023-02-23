#pragma once

#include "../macros.hpp"
#include "miniaudio/miniaudio.h"

// ================================================================================
// Defines and Macros
// ================================================================================

#ifndef AUDIO_DEVICE_FORMAT
#define AUDIO_DEVICE_FORMAT    ma_format_f32    // Device output format (float-32bit)
#endif
#ifndef AUDIO_DEVICE_CHANNELS
#define AUDIO_DEVICE_CHANNELS              2    // Device output channels: stereo
#endif
#ifndef AUDIO_DEVICE_SAMPLE_RATE
#define AUDIO_DEVICE_SAMPLE_RATE           0    // Device output sample rate
#endif

#ifndef MAX_AUDIO_BUFFER_POOL_CHANNELS
#define MAX_AUDIO_BUFFER_POOL_CHANNELS    16    // Audio pool channels
#endif


// ================================================================================
// Types and structures definitions
// ================================================================================

// Enums

typedef enum
{
    MUSIC_AUDIO_NONE = 0,
    MUSIC_AUDIO_WAV,
    MUSIC_AUDIO_OGG,
    MUSIC_AUDIO_FLAC,
    MUSIC_AUDIO_MP3
} MusicContextType;

typedef enum
{
    LOG_ALL = 0,
    LOG_TRACE,
    LOG_DEBUG,
    LOG_INFO,
    LOG_WARNING,
    LOG_ERROR,
    LOG_FATAL,
    LOG_NONE
} TraceLogLevel;

// ================================================================================
//
// ================================================================================

struct RIQAudioBuffer
{
    ma_data_converter converter;

    float volume;
    float pitch;
    float pan;

    bool playing;
    bool paused;
    bool looping;

    RIQAudioBuffer* next;
    RIQAudioBuffer* prev;
};

DllExport class RIQAudio
{
private:
    ma_context context;
    ma_device device;
    ma_engine engine;
    ma_mutex lock;
    bool isReady;
    size_t pcmBufferSize;
    void* pcmBuffer;

    RIQAudioBuffer* firstBuffer;
    RIQAudioBuffer* lastBuffer;
    int defaultBufferSize;
public:
    RIQAudio();
    ~RIQAudio();
    ma_result Init();
};