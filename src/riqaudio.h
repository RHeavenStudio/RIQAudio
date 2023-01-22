#include "shinobu_audio.h"
#include <vector>
#include <stdlib.h>

typedef std::string string;

class RIQAudioData
{
    uint8_t *data;
    uint64_t size;

    public:
    void load_from_memory(const float p_data[], uint64_t p_size) {
        data = new uint8_t[size];
        size = p_size;

        for (uint64_t i = 0; i < size; i++) {
            // convert float values to uint8_t
            data[i] = (uint8_t)(p_data[i] * 255);
        }
    }

    const uint8_t* ptr() {
        return (uint8_t*)data;
    }

    uint64_t get_size() {
        return size;   
    }

    RIQAudioData() {}

    ~RIQAudioData() {
        delete[] data;
    }
};

class RIQAudio
{
private:
    static RIQAudio *instance;
    ShinobuAudio *shinobu;
    ma_backend string_to_backend(string str);
public:
    static RIQAudio *get_instance();

    ma_result initialize();

    uint64_t get_dsp_time() const;
    void set_dsp_time(uint64_t m_new_time_msec);
    ma_result register_group(string group_name, string parent_group_name);
    
    ma_result register_sound

    RIQAudio();
    ~RIQAudio();

};