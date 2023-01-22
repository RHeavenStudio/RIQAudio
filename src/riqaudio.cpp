#include "riqaudio.h"

RIQAudio *RIQAudio::instance = nullptr;

ma_result RIQAudio::initialize() {
    /* 
        note
        do this in the C# side 
    */
    // #ifdef X11_ENABLED
    // String deck_variable = OS::get_singleton()->get_environment("SteamDeck");
    // if (!deck_variable.empty() && deck_variable.to_int64() > 0) {
    //     backend_to_force = ma_backend_alsa;
    // }
    // #endif

    return shinobu->initialize();
}