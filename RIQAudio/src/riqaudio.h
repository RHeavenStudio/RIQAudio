#include "miniaudio/miniaudio.h"

typedef struct AudioStream
{
	ma_engine* engine;
	ma_device* device;
	ma_context* context;
	ma_resource_manager* resource_manager;
} AudioStream;