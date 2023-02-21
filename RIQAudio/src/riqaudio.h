#include "miniaudio/miniaudio.h"

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

DllExport void riq_init(const char* fileLocation);
DllExport void riq_play();
DllExport void riq_dispose(AudioStream* stream);