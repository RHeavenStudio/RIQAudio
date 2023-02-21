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

DllExport AudioStream riq_init()
{
    printf("Struct initialized!");
}

DllExport ma_result riq_dispose()
{
    /*ma_device_uninit(device);
    ma_context_uninit(context);

    free(device);
    free(context);*/
}