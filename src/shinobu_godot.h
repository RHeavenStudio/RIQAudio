#ifndef SHINOBU_GODOT_H
#define SHINOBU_GODOT_H
#include "shinobu_audio.h"
#include "core/object.h"
#include "core/ustring.h"
#include "core/os/file_access.h"
#include "core/reference.h"
#include <vector>

class ShinobuGodotEffect : public Reference {
    GDCLASS(ShinobuGodotEffect, Reference);
protected:
    static void _bind_methods() {
        ClassDB::bind_method(D_METHOD("connect_to_effect", "effect"), &ShinobuGodotEffect::connect_to_effect);
    }
public:
    virtual ShinobuAudioEffect* get_effect() = 0;
    virtual int64_t connect_to_effect(Ref<ShinobuGodotEffect> m_effect) = 0;
};

class ShinobuGodotEffectChannelRemap : public ShinobuGodotEffect {
    GDCLASS(ShinobuGodotEffectChannelRemap, ShinobuGodotEffect);
    std::unique_ptr<ShinobuChannelRemap> channel_remap;

protected:
    static void _bind_methods() {
        ClassDB::bind_method(D_METHOD("set_weight", "channel_in", "channel_out", "weight"), &ShinobuGodotEffectChannelRemap::set_weight);
    }

public:
    ShinobuGodotEffectChannelRemap(std::unique_ptr<ShinobuChannelRemap> channel_remap) 
    : channel_remap(std::move(channel_remap)) {}
    
    ShinobuAudioEffect* get_effect() {
        return channel_remap.get();
    }

    void set_weight(uint32_t channel_in, uint32_t channel_out, float weight) {
        channel_remap->set_weight(channel_in, channel_out, weight);
    }

    int64_t connect_to_effect(Ref<ShinobuGodotEffect> m_effect) {
        return channel_remap->connect_to_node(m_effect->get_effect()->get_node());
    }
};

class ShinobuGodotEffectSpectrumAnalyzer : public ShinobuGodotEffect {
    GDCLASS(ShinobuGodotEffectSpectrumAnalyzer, ShinobuGodotEffect);
    std::unique_ptr<ShinobuSpectrumAnalyzer> spectrum_analyzer;
protected:
    static void _bind_methods() {
        ClassDB::bind_method(D_METHOD("get_magnitude_for_frequency_range", "begin", "end", "mode"), &ShinobuGodotEffectSpectrumAnalyzer::get_magnitude_for_frequency_range, DEFVAL(MAGNITUDE_MAX));
        BIND_ENUM_CONSTANT(MAGNITUDE_AVERAGE);
        BIND_ENUM_CONSTANT(MAGNITUDE_MAX);
    }
public:
    ShinobuGodotEffectSpectrumAnalyzer(std::unique_ptr<ShinobuSpectrumAnalyzer> spectrum_analyzer) 
    : spectrum_analyzer(std::move(spectrum_analyzer)) {}
    
    ShinobuAudioEffect* get_effect() {
        return spectrum_analyzer.get();
    }

    int64_t connect_to_effect(Ref<ShinobuGodotEffect> m_effect) {
        return spectrum_analyzer->connect_to_node(m_effect->get_effect()->get_node());
    }

    Vector2 get_magnitude_for_frequency_range(float m_begin, float m_end, ma_spectrum_magnitude_mode mode = MAGNITUDE_MAX) {
        MagnitudeResult res = spectrum_analyzer->get_magnitude_for_frequency_range(m_begin, m_end, mode);
        return Vector2(res.l, res.r);
    }
};

VARIANT_ENUM_CAST(ma_spectrum_magnitude_mode);

class ShinobuGodotEffectPitchShift : public ShinobuGodotEffect {
    GDCLASS(ShinobuGodotEffectPitchShift, ShinobuGodotEffect);
    std::unique_ptr<ShinobuPitchShift> pitch_shift;
protected:
    static void _bind_methods() {
        ClassDB::bind_method(D_METHOD("get_pitch_scale"), &ShinobuGodotEffectPitchShift::get_pitch_scale);
        ClassDB::bind_method(D_METHOD("set_pitch_scale", "pitch_scale"), &ShinobuGodotEffectPitchShift::set_pitch_scale);
	    ADD_PROPERTY(PropertyInfo(Variant::REAL, "pitch_scale"), "set_pitch_scale", "get_pitch_scale");
    }
public:
    ShinobuGodotEffectPitchShift(std::unique_ptr<ShinobuPitchShift> pitch_shift) 
    : pitch_shift(std::move(pitch_shift)) {}

    float get_pitch_scale() const {
        return pitch_shift->get_pitch_scale();
    }

    void set_pitch_scale(float pitch_scale) {
        pitch_shift->set_pitch_scale(pitch_scale);
    }

    int64_t connect_to_effect(Ref<ShinobuGodotEffect> m_effect) {
        return pitch_shift->connect_to_node(m_effect->get_effect()->get_node());
    }

    ShinobuAudioEffect* get_effect() {
        return pitch_shift.get();
    }
};

class ShinobuGodotSoundPlayback : public Reference {
    GDCLASS(ShinobuGodotSoundPlayback, Reference)
    std::unique_ptr<ShinobuSoundPlayback> playback;
protected:
	static void _bind_methods() {
        ClassDB::bind_method(D_METHOD("start"), &ShinobuGodotSoundPlayback::start);
        ClassDB::bind_method(D_METHOD("stop"), &ShinobuGodotSoundPlayback::stop);
        ClassDB::bind_method(D_METHOD("set_pitch_scale", "pitch_scale"), &ShinobuGodotSoundPlayback::set_pitch_scale);
        ClassDB::bind_method(D_METHOD("get_pitch_scale"), &ShinobuGodotSoundPlayback::get_pitch_scale);
	    ADD_PROPERTY(PropertyInfo(Variant::REAL, "pitch_scale"), "set_pitch_scale", "get_pitch_scale");
        ClassDB::bind_method(D_METHOD("schedule_start_time", "global_time_msec"), &ShinobuGodotSoundPlayback::schedule_start_time);
        ClassDB::bind_method(D_METHOD("schedule_stop_time", "global_time_msec"), &ShinobuGodotSoundPlayback::schedule_stop_time);
        ClassDB::bind_method(D_METHOD("get_playback_position_msec"), &ShinobuGodotSoundPlayback::get_playback_position_msec);
        ClassDB::bind_method(D_METHOD("get_length_msec"), &ShinobuGodotSoundPlayback::get_length_msec);
        ClassDB::bind_method(D_METHOD("seek", "to_time_msec"), &ShinobuGodotSoundPlayback::seek);
        ClassDB::bind_method(D_METHOD("set_volume", "linear_volume"), &ShinobuGodotSoundPlayback::set_volume);
        ClassDB::bind_method(D_METHOD("get_volume"), &ShinobuGodotSoundPlayback::get_volume);
        ClassDB::bind_method(D_METHOD("is_playing"), &ShinobuGodotSoundPlayback::is_playing);
	    ADD_PROPERTY(PropertyInfo(Variant::REAL, "volume"), "set_volume", "get_volume");
        ClassDB::bind_method(D_METHOD("get_looping_enabled"), &ShinobuGodotSoundPlayback::get_looping_enabled);
        ClassDB::bind_method(D_METHOD("set_looping_enabled", "looping_enabled"), &ShinobuGodotSoundPlayback::set_looping_enabled);
	    ADD_PROPERTY(PropertyInfo(Variant::BOOL, "looping_enabled"), "set_looping_enabled", "get_looping_enabled");
        ClassDB::bind_method(D_METHOD("connect_sound_to_effect", "effect"), &ShinobuGodotSoundPlayback::connect_sound_to_effect);
        ClassDB::bind_method(D_METHOD("get_channel_count"), &ShinobuGodotSoundPlayback::get_channel_count);
    }
public:
    ShinobuGodotSoundPlayback(std::unique_ptr<ShinobuSoundPlayback> playback) 
    : playback(std::move(playback)) {}

    uint64_t get_channel_count() const {
        return playback->get_channel_count();
    }

    uint64_t start() {
        return playback->start();
    }

    uint64_t stop() {
        return playback->stop();
    }

    void set_pitch_scale(float pitch_scale) {
        playback->set_pitch_scale(pitch_scale);
    }

    float get_pitch_scale() const {
        return playback->get_pitch_scale();
    }

    void schedule_start_time(uint64_t global_time_msec) {
        playback->schedule_start_time(global_time_msec);
    }
    void schedule_stop_time(uint64_t global_time_msec) {
        playback->schedule_stop_time(global_time_msec);
    }

    uint64_t get_playback_position_msec() {
        return playback->get_playback_position_msec();
    }
    uint64_t get_length_msec() {
        return playback->get_length_msec();
    }
    uint64_t seek(uint64_t to_time_msec) {
        return playback->seek(to_time_msec);
    }
    void set_volume(float linear_volume) {
        playback->set_volume(linear_volume);
    }
    float get_volume() {
        return playback->get_volume();
    }

    bool is_playing() {
        return playback->is_playing();
    }

    void set_looping_enabled(bool m_looping_enabled) {
        playback->set_looping_enabled(m_looping_enabled);
    }

    bool get_looping_enabled() const {
        return playback->get_looping_enabled();
    }

    int64_t connect_sound_to_effect(Ref<ShinobuGodotEffect> m_effect) {
        return playback->connect_effect(m_effect->get_effect());
    }
};

class ShinobuGodotAudioFile : public Reference {
    GDCLASS(ShinobuGodotAudioFile, Reference);
    
    uint8_t *data;
    uint64_t size;

protected:
	static void _bind_methods() {
        ClassDB::bind_method(D_METHOD("load_from_file", "file_path"), &ShinobuGodotAudioFile::load_from_file);
        ClassDB::bind_method(D_METHOD("load_from_memory", "data"), &ShinobuGodotAudioFile::load_from_memory);
        ClassDB::bind_method(D_METHOD("get_size"), &ShinobuGodotAudioFile::get_size);
    }

public:
    Error load_from_file(String m_file_path) {
        FileAccess *f;
        Error err = OK;
        f = FileAccess::open(m_file_path, FileAccess::READ, &err);

        if (err == OK) {
            uint64_t len = f->get_len();
            data = new uint8_t[len];
            size = f->get_buffer(data, len);
        }

        memdelete(f);

        return err;
    }

    void load_from_memory(const PoolVector<uint8_t> &p_data) {
        data = new uint8_t[p_data.size()];
        size = p_data.size();
        // Copy sound data so we own it
        memcpy(data, p_data.read().ptr(), p_data.size());
    }

    const uint8_t* ptr() {
        return (uint8_t*)data;
    }

    uint64_t get_size() {
        return size;   
    }

    ShinobuGodotAudioFile() {}

    ~ShinobuGodotAudioFile() {
        delete[] data;
    }
};

class ShinobuGodot : public Object {
    GDCLASS(ShinobuGodot, Object)
private:
	static ShinobuGodot *singleton;
    ShinobuAudio *shinobu;
    ma_backend string_to_backend(String str);
protected:
	static void _bind_methods();
public:
    _FORCE_INLINE_ static ShinobuGodot *get_singleton() { return singleton; }

    uint64_t initialize();

    uint64_t get_dsp_time() const;
    void set_dsp_time(uint64_t m_new_time_msec);
    int64_t register_group(String m_group_name, String m_parent_group_name = "");
    Error register_sound_from_path(String m_path, String m_sound_name);
    int64_t register_sound(Ref<ShinobuGodotAudioFile> audio_file, String m_sound_name);
    void unregister_sound(String m_sound_name);
    Ref<ShinobuGodotSoundPlayback> instantiate_sound(String sound_name, String group_name, bool use_source_channel_count = false);
    int64_t fire_and_forget_sound(String sound_name, String group_name);
    void set_group_volume(String group_name, float linear_volume);
    float get_group_volume(String group_name);

    int64_t set_master_volume(float linear_volume);
    float get_master_volume();

    void set_buffer_size(uint64_t m_buffer_size);
    uint64_t get_buffer_size() const;

    Ref<ShinobuGodotEffectSpectrumAnalyzer> instantiate_spectrum_analyzer();
    Ref<ShinobuGodotEffectPitchShift> instantiate_pitch_shift();
    Ref<ShinobuGodotEffectChannelRemap> instantiate_channel_remap(uint32_t channel_count_in, uint32_t channel_count_out);

    uint64_t connect_group_to_effect(String m_group_name, Ref<ShinobuGodotEffect> m_effect);

    uint64_t get_actual_buffer_size() const;
    int64_t connect_effect_to_endpoint(Ref<ShinobuGodotEffect> m_effect);
    int64_t connect_effect_to_group(Ref<ShinobuGodotEffect> m_effect, String m_group_name);
    int64_t connect_group_to_endpoint(String m_group_name);

    String get_current_backend_name() const;

    ShinobuGodot();
    ~ShinobuGodot();
};

#endif