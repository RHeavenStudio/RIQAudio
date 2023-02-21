#include "macros.h"

#include "riqaudio.h"

#define SUPPORT_FILEFORMAT_OGG
#define SUPPORT_FILEFORMAT_WAV

#if defined(SUPPORT_FILEFORMAT_OGG)
    #define STB_VORBIS_IMPLEMENTATION
    #include "miniaudio/external/stb_vorbis.h" // Vorbis decoding
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

void data_callback(ma_device* pDevice, void* pOutput, const void* pInput, ma_uint32 frameCount)
{
    ma_decoder* pDecoder = (ma_decoder*)pDevice->pUserData;
    if (pDecoder == NULL) {
        return;
    }

    ma_decoder_read_pcm_frames(pDecoder, pOutput, frameCount, NULL);

    (void)pInput;
}

void riq_init(const char* fileLocation)
{
    if (fileLocation == NULL)
    {
        printf("No input file.");
        return;
    }

    result = ma_decoder_init_file(fileLocation, NULL, &decoder);
    if (result != MA_SUCCESS)
    {
        printf("Could not load file: %s\n", fileLocation);
        return;
    }

    deviceConfig = ma_device_config_init(ma_device_type_playback);
    deviceConfig.playback.format = decoder.outputFormat;
    deviceConfig.playback.channels = decoder.outputChannels;
    deviceConfig.sampleRate = decoder.outputSampleRate;
    deviceConfig.dataCallback = data_callback;
    deviceConfig.pUserData = &decoder;

    if (ma_device_init(NULL, &deviceConfig, &device) != MA_SUCCESS) {
        printf("Failed to open playback device.\n");
        ma_decoder_uninit(&decoder);
        return;
    }

    printf("Initialized!\n");
}

void riq_play()
{
    if (ma_device_start(&device) != MA_SUCCESS) {
        printf("Failed to start playback device.\n");
        ma_device_uninit(&device);
        ma_decoder_uninit(&decoder);
        return;
    }

    printf("Playing!\n");
}

void riq_dispose(AudioStream* stream)
{
    ma_device_uninit(&device);
    ma_decoder_uninit(&decoder);

    printf("Deinitialized!\n");
}