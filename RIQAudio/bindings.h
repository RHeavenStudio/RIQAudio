#include <cstdarg>
#include <cstdint>
#include <cstdlib>
#include <ostream>
#include <new>

extern "C" {

void riq_init_audio_device();

bool riq_is_ready();

void riq_close_audio_device();

} // extern "C"
