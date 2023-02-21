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

ma_result result;
ma_decoder decoder;
ma_device_config deviceConfig;
ma_device device;

typedef struct AudioStream
{
	ma_engine* engine;
	ma_device* device;
	ma_context* context;
	ma_resource_manager* resource_manager;
} AudioStream;

#ifdef __cplusplus
extern "C" {
#endif

DllExport void riq_init(const char* fileLocation);
DllExport void riq_play();
DllExport void riq_dispose(AudioStream* stream);

#ifdef __cplusplus
}
#endif

typedef void (*AudioCallback)(void* bufferdata, unsigned int frames);

typedef struct riqAudioBuffer riqAudioBuffer;
typedef struct riqAudioProcessor riqAudioProcessor;