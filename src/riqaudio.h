#include "miniaudio/miniaudio.h"

class RIQAudio
{
private:
    ma_engine *engine;
    ma_device *device;
    ma_context *context;
    ma_resource_manager *resource_manager;
    UINT64 buffer_size = 0;
public:
    RIQAudio();
    ~RIQAudio();
    ma_result init();
};