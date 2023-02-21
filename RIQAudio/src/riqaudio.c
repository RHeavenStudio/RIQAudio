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

#include <stdio.h>

__declspec(dllexport) void playTest(const char* filePath)
{
    ma_result result;
    ma_engine engine;

    if (filePath == NULL < 2) {
        printf("No input file.");
        return -1;
    }

    result = ma_engine_init(NULL, &engine);
    if (result != MA_SUCCESS) {
        printf("Failed to initialize audio engine.");
        return -1;
    }

    ma_engine_play_sound(&engine, filePath, NULL);

    printf("Press Enter to quit...");
    getchar();

    ma_engine_uninit(&engine);
}