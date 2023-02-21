#define MINIAUDIO_IMPLEMENTATION
#include "miniaudio/miniaudio.h"

#include <iostream>
#include <stdio.h>
#include <string.h>

int main()
{
    ma_result result;
    ma_engine engine;

    std::string fileLoc = "C:/Users/Braedon/Music/Title Theme Finished.wav";

    if (fileLoc.length() < 2) {
        printf("No input file.");
        return -1;
    }

    result = ma_engine_init(NULL, &engine);
    if (result != MA_SUCCESS) {
        printf("Failed to initialize audio engine.");
        return -1;
    }

    ma_engine_play_sound(&engine, fileLoc.c_str(), NULL);

    printf("Press Enter to quit...");
    getchar();

    ma_engine_uninit(&engine);

    return 0;
}