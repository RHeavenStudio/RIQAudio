#ifndef SHINOBU_AUDIO_H
#define SHINOBU_AUDIO_H

#include "miniaudio/miniaudio.h"
#include "shinobu_sound_data.h"
#include <cstring>
#include <string>
#include <map>
#include <memory>
#include <chrono>
#include <atomic>
#include <vector>

#include "shinobu_spectrum_analyzer.h"
#include "shinobu_pitch_shift.h"
#include "shinobu_channel_remap.h"

#define SH_RESULT ma_result
#define SH_SUCCESS MA_SUCCESS

typedef std::chrono::milliseconds milliseconds;

class ShinobuAudioEffect {
protected:
    bool initialized;
    ma_engine *engine;
public:
    virtual int64_t initialize(uint32_t channelCount) { return 0; };
    virtual int64_t initialize(uint32_t in_channel_count, uint32_t out_channel_count) { return 0; };
    virtual int64_t connect_to_node(ma_node* node) = 0;
    ShinobuAudioEffect(ma_engine *engine) : initialized(false), engine(engine) {};
    virtual ~ShinobuAudioEffect() {};
    virtual ma_node* get_node() = 0;
};

class ShinobuChannelRemap : public ShinobuAudioEffect {
private:
    ma_channel_remap_node* remap_node;
    std::vector<uint8_t> channelMapIn;
    std::vector<uint8_t> channelMapOut;
public:
    ShinobuChannelRemap(ma_engine *engine) : ShinobuAudioEffect(engine) {
        remap_node = new ma_channel_remap_node;
    }
    ~ShinobuChannelRemap() {
        ma_channel_remap_node_uninit(remap_node, NULL);
    }

    int64_t initialize(uint32_t in_channel_count, uint32_t out_channel_count) override {
        ma_channel_remap_node_config mapNodeConfig = ma_channel_remap_node_config_init(ma_engine_get_sample_rate(engine), in_channel_count, out_channel_count);
        ma_result result = ma_channel_remap_node_init(ma_engine_get_node_graph(engine), &mapNodeConfig, NULL, remap_node);
        initialized = true;
        return result;
    }

    void set_weight(uint8_t channel_in, uint8_t channel_out, float weight) {
        ma_channel_remap_node_set_weight(remap_node, channel_in, channel_out, weight);
    }

    int64_t connect_to_node(ma_node* node) override {
        ma_result res = ma_node_attach_output_bus(remap_node, 0, node, 0);
        return res;
    }

    ma_node* get_node() override {
        return (ma_node*)remap_node;
    }
};

class ShinobuSpectrumAnalyzer : public ShinobuAudioEffect {
    ma_spectrum_analyzer_node* analyzer_node;
public:
    ShinobuSpectrumAnalyzer(ma_engine *engine) : ShinobuAudioEffect(engine) {
        analyzer_node = new ma_spectrum_analyzer_node;
    }

    int64_t initialize(uint32_t channelCount) override {
        ma_spectrum_analyzer_config spectrumConfig = ma_spectrum_analyzer_config_init(ma_engine_get_sample_rate(engine));
        ma_result result = ma_spectrum_analyzer_node_init(ma_engine_get_node_graph(engine), &spectrumConfig, NULL, analyzer_node);
        initialized = true;
        return result;
    }

    int64_t connect_to_node(ma_node* node) override {
        ma_result res = ma_node_attach_output_bus(analyzer_node, 0, node, 0);
        return res;
    }

    ma_node* get_node() override {
        return (ma_node*)analyzer_node;
    }

    MagnitudeResult get_magnitude_for_frequency_range(float pBegin, float pEnd, ma_spectrum_magnitude_mode mode = MAGNITUDE_MAX) {
        return ma_spectrum_analyzer_get_magnitude_for_frequency_range(pBegin, pEnd, mode, analyzer_node);
    }

    ~ShinobuSpectrumAnalyzer() {
        ma_spectrum_analyzer_node_uninit(analyzer_node, NULL);
        delete analyzer_node;
    }
};

class ShinobuPitchShift : public ShinobuAudioEffect {
    ma_pitch_shift_node *shift_node;
public:
    int64_t initialize(uint32_t channelCount) override {
        ma_pitch_shift_node_config pitchShiftconfig = ma_pitch_shift_node_config_init(ma_engine_get_sample_rate(engine));
        ma_result result = ma_pitch_shift_node_init(ma_engine_get_node_graph(engine), &pitchShiftconfig, NULL, shift_node);
        initialized = true;
        return result;
    }

    ShinobuPitchShift(ma_engine *engine) : ShinobuAudioEffect(engine) {
        shift_node = new ma_pitch_shift_node;
    }

    ma_node* get_node() override {
        return (ma_node*)shift_node;
    }

    void set_pitch_scale(float pitch_scale) {
        ma_pitch_shift_node_set_pitch_scale(shift_node, pitch_scale);
    }

    float get_pitch_scale() {
        return ma_pitch_shift_node_get_pitch_scale(shift_node);
    }

    int64_t connect_to_node(ma_node* node) override {
        ma_result res = ma_node_attach_output_bus(shift_node, 0, node, 0);
        return res;
    }

    ~ShinobuPitchShift() {
        ma_pitch_shift_node_uninit(shift_node, NULL);
        delete shift_node;
    }
};

class ShinobuClock {
    std::atomic<uint64_t> last_recorded_time;
    
public:
    ShinobuClock() {
        std::atomic_init(&last_recorded_time, (uint64_t)0);
    }

    uint64_t get_current_offset_msec() {
        std::chrono::high_resolution_clock::time_point now = std::chrono::high_resolution_clock::now();
        std::chrono::high_resolution_clock::time_point lrt(milliseconds(last_recorded_time.load(std::memory_order_seq_cst)));
        auto diff = std::chrono::duration_cast<milliseconds>(now - lrt);
        return diff.count();
    }

    void measure() {
        uint64_t ms_count = std::chrono::time_point_cast<milliseconds>(std::chrono::high_resolution_clock::now()).time_since_epoch().count();
        last_recorded_time.store(ms_count, std::memory_order_seq_cst);
    }
};
class ShinobuSoundGroup {
    ma_sound_group *sound_group;
    SH_RESULT result;
    std::string name;
public:
    ShinobuSoundGroup(ma_engine *engine, std::string name, ma_sound_group* parent_group)
    : name(name) {
        sound_group = new ma_sound_group;
        result = ma_sound_group_init(engine, 0, parent_group, sound_group);
    }

    SH_RESULT get_result() {
        return result;
    }
    ma_sound_group* get_sound_group() {
        return sound_group;
    }

    void set_volume(float linear_volume) {
        ma_sound_group_set_volume(sound_group, linear_volume);
    }

    const float get_volume() {
        return ma_sound_group_get_volume(sound_group);
    }

    ~ShinobuSoundGroup() {
        ma_sound_group_uninit(sound_group);
        delete sound_group;
    }
};

class ShinobuSoundPlayback {
    ma_sound *sound;
    ma_engine *engine;
    SH_RESULT result;
    uint64_t start_time_msec = 0;
    int64_t cached_length = -1;
    bool looping = false;
    ShinobuClock *clock;
public:
    ShinobuSoundPlayback(ma_engine *engine, std::string name, ma_sound_group *sound_group, ShinobuClock *clock, bool use_source_channel_count = false)
    : engine(engine), clock(clock) {
        sound = new ma_sound;
        ma_sound_config config = ma_sound_config_init();
        config.pFilePath = name.c_str();
        config.flags = config.flags | MA_SOUND_FLAG_NO_SPATIALIZATION;
        if (use_source_channel_count) {
            config.flags = config.flags | MA_SOUND_FLAG_NO_DEFAULT_ATTACHMENT;
            config.channelsOut = MA_SOUND_SOURCE_CHANNEL_COUNT;
        } else {
            config.pInitialAttachment = sound_group;
        }
        
        result = ma_sound_init_ex(engine, &config, sound);
    }
    
    ~ShinobuSoundPlayback() {
        ma_sound_uninit(sound);
        delete sound;
    }
    
    SH_RESULT get_result() {
        return result;
    }

    SH_RESULT seek(uint64_t to_time_msec) {
        // Sound MUST be stopped before seeking or we crash
        if (ma_sound_is_playing(sound) == MA_TRUE) {
            ma_sound_stop(sound);
        }
        uint32_t sample_rate;
        ma_sound_get_data_format(sound, NULL, NULL, &sample_rate, NULL, 0);
        return ma_sound_seek_to_pcm_frame(sound, to_time_msec * (float)(sample_rate / 1000.0f));
    }

    uint32_t get_channel_count() {
        uint32_t channels;
        if (ma_sound_get_data_format(sound, NULL, &channels, NULL, NULL, 0) == MA_SUCCESS) {
            return channels;
        } else {
            return 2;
        }
    }

    bool is_playing() {
        return (bool)ma_sound_is_playing(sound);
    }
    
    SH_RESULT start() {
        return ma_sound_start(sound);
    }
    
    SH_RESULT stop() {
        return ma_sound_stop(sound);
    }

    void set_pitch_scale(float pitch_scale) {
        ma_sound_set_pitch(sound, pitch_scale);
    }

    float get_pitch_scale() const {
        return ma_sound_get_pitch(sound);
    }

    void schedule_start_time(uint64_t global_time_msec) {
        start_time_msec = global_time_msec;
        ma_sound_set_start_time_in_milliseconds(sound, global_time_msec);
    }

    void schedule_stop_time(uint64_t global_time_msec) {
        ma_sound_set_stop_time_in_milliseconds(sound, global_time_msec);
    }

    uint64_t get_playback_position_msec() {

        
        ma_uint64 pos_frames;
        result = ma_sound_get_cursor_in_pcm_frames(sound, &pos_frames);
        uint64_t out_pos = 0;
        uint32_t sample_rate;
        ma_sound_get_data_format(sound, NULL, NULL, &sample_rate, NULL, 0);
        if (result == SH_SUCCESS) {
           out_pos = pos_frames / (float)(sample_rate/ 1000.0f);
        }
        
        // This allows the return of negative playback time
        uint64_t dsp_time = ma_engine_get_time(engine) / (float)(ma_engine_get_sample_rate(engine) / 1000.0f);

        if (!is_playing() && start_time_msec > dsp_time) {
            return dsp_time - start_time_msec + out_pos;
        }

        if (is_playing()) {
            out_pos += clock->get_current_offset_msec();
        }

        return out_pos;
    }

    uint64_t get_length_msec() {
        if (cached_length != -1) {
            return cached_length;
        }

        ma_uint64 p_length = 0;
        ma_sound_get_length_in_pcm_frames(sound, &p_length);
        uint32_t sample_rate;
        ma_sound_get_data_format(sound, NULL, NULL, &sample_rate, NULL, 0);
        p_length /= (float)(sample_rate / 1000.0f);
        cached_length = p_length;

        return p_length;
    }

    void set_volume(float linear_volume) {
        ma_sound_set_volume(sound, linear_volume);
    }

    float get_volume() const {
        return ma_sound_get_volume(sound);
    }

    void set_looping_enabled(bool m_looping) {
        looping = m_looping;
        ma_sound_set_looping(sound, (ma_bool32)m_looping);
    }

    bool get_looping_enabled() const {
        return looping;
    }

    uint64_t connect_effect(ShinobuAudioEffect* m_effect) {
        return ma_node_attach_output_bus(sound, 0, m_effect->get_node(), 0);
    }
};
class ShinobuAudio {
private:
    std::map<std::string, std::unique_ptr<ShinobuSoundSource>> sound_datas;
    std::map<std::string, std::unique_ptr<ShinobuSoundGroup>> sound_groups;
    ma_engine *engine;
    ma_device *device;
    ma_resource_manager *resource_manager;
    ma_context *context;
    uint64_t buffer_size = 10;
    bool is_initialized = false;
    ShinobuClock *clock;

    float master_volume = 1.0f;
    static void ma_data_callback(ma_device* pDevice, void* pOutput, const void* pInput, ma_uint32 frameCount);
    ShinobuSoundGroup* get_group(std::string name);
    ma_sound_group* get_ma_group(std::string name);
    ShinobuSoundSource* get_sound_source(std::string name);
public:
    uint64_t get_dsp_time() const;
    void set_dsp_time(uint64_t new_time_msec);

    SH_RESULT register_sound_from_memory(std::string name, const void* data, size_t size);
    SH_RESULT register_group(std::string name, std::string parent_group_name = "");
    void unregister_sound(std::string name);

    SH_RESULT fire_and_forget_sound(std::string sound_name, std::string group_name);
    std::unique_ptr<ShinobuSoundPlayback> instantiate_sound(std::string name, std::string group_name, bool use_source_channel_count = false);
    SH_RESULT initialize(ma_backend forced_backend = ma_backend_null);

    void set_group_volume(std::string name, float linear_volume);
    float get_group_volume(std::string name);

    SH_RESULT set_master_volume(float linear_volume);
    float get_master_volume();

    uint64_t get_buffer_size() const;
    void set_buffer_size(uint64_t new_buffer_size);

    uint64_t get_actual_buffer_size() const;

    ma_engine* get_engine();

    uint64_t connect_group_to_effect(std::string group_name, ShinobuAudioEffect* effect);
    uint64_t connect_effect_to_group(ShinobuAudioEffect* effect, std::string group_name);
    uint64_t connect_group_to_endpoint(std::string group_name);

    std::string get_current_backend_name() const;

    ShinobuAudio();
    ~ShinobuAudio();
};

#endif