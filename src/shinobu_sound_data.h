#ifndef SHINOBU_SOUND_DATA_H
#define SHINOBU_SOUND_DATA_H
#include "shinobu_audio.h"

#include "miniaudio/miniaudio.h"
#include <string>
#include <cstring>

class ShinobuSoundSource {
protected:
    ma_engine *engine;
    std::string name;
    ma_result result;
public:
    ShinobuSoundSource(ma_engine *engine, std::string name) : engine(engine), name(name) {};
    virtual const std::string get_name() const {
        return name;
    }

    virtual const ma_result get_result() const {
        return result;
    }

    virtual const uint64_t get_fixed_length() const {
        return 0.0f;
    }
    virtual ~ShinobuSoundSource() {};
};

class ShinobuSoundSourceMemory : public ShinobuSoundSource {
    void *data;
public:
    ShinobuSoundSourceMemory(ma_engine *engine, std::string name, const void* in_data, size_t size)
    : ShinobuSoundSource(engine, name) {
        data = malloc(size);
        std::memcpy(data, in_data, size);
        result = ma_resource_manager_register_encoded_data(ma_engine_get_resource_manager(engine), name.c_str(), data, size);
    }


    ~ShinobuSoundSourceMemory() {
        ma_resource_manager_unregister_data(ma_engine_get_resource_manager(engine), name.c_str());
        free(data);
    }
};

class ShinobuSoundSourceFile : public ShinobuSoundSource {
public:
    ShinobuSoundSourceFile(ma_engine *engine, std::string file_path)
    : ShinobuSoundSource(engine, file_path) {
        result = ma_resource_manager_register_file(ma_engine_get_resource_manager(engine), name.c_str(), 0);
    }
    ~ShinobuSoundSourceFile() {
        ma_resource_manager_unregister_file(ma_engine_get_resource_manager(engine), name.c_str());
    }
};

#endif