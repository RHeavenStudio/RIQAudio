#include "shinobu_godot.h"
#include "core/os/os.h"

ShinobuGodot *ShinobuGodot::singleton = nullptr;

void ShinobuGodot::_bind_methods() {
	ClassDB::bind_method(D_METHOD("get_dsp_time"), &ShinobuGodot::get_dsp_time);
	ClassDB::bind_method(D_METHOD("set_dsp_time", "new_time"), &ShinobuGodot::set_dsp_time);
	ClassDB::bind_method(D_METHOD("register_group", "group_name", "parent_group_name"), &ShinobuGodot::register_group, DEFVAL(""));
	ClassDB::bind_method(D_METHOD("register_sound_from_path", "path", "sound_name"), &ShinobuGodot::register_sound_from_path);
	ClassDB::bind_method(D_METHOD("register_sound", "audio_file", "sound_name"), &ShinobuGodot::register_sound);
	ClassDB::bind_method(D_METHOD("unregister_sound", "sound_name"), &ShinobuGodot::unregister_sound);
	ClassDB::bind_method(D_METHOD("instantiate_sound", "sound_name", "group_name", "use_source_channel_count"), &ShinobuGodot::instantiate_sound, DEFVAL(false));
	ClassDB::bind_method(D_METHOD("fire_and_forget_sound", "sound_name", "group_name"), &ShinobuGodot::fire_and_forget_sound);
	ClassDB::bind_method(D_METHOD("set_group_volume", "group_name", "linear_volume"), &ShinobuGodot::set_group_volume);
	ClassDB::bind_method(D_METHOD("get_group_volume", "group_name"), &ShinobuGodot::get_group_volume);
	ClassDB::bind_method(D_METHOD("set_master_volume", "linear_volume"), &ShinobuGodot::set_master_volume);
	ClassDB::bind_method(D_METHOD("get_master_volume"), &ShinobuGodot::get_master_volume);
    ClassDB::bind_method(D_METHOD("get_buffer_size"), &ShinobuGodot::get_buffer_size);
    ClassDB::bind_method(D_METHOD("set_buffer_size", "buffer_size"), &ShinobuGodot::set_buffer_size);
    ADD_PROPERTY(PropertyInfo(Variant::INT, "buffer_size"), "set_buffer_size", "get_buffer_size");
    ClassDB::bind_method(D_METHOD("initialize"), &ShinobuGodot::initialize);
    ClassDB::bind_method(D_METHOD("instantiate_spectrum_analyzer"), &ShinobuGodot::instantiate_spectrum_analyzer);
    ClassDB::bind_method(D_METHOD("instantiate_channel_remap", "channel_count_in", "channel_count_out"), &ShinobuGodot::instantiate_channel_remap);
    ClassDB::bind_method(D_METHOD("connect_group_to_effect", "group_name", "effect"), &ShinobuGodot::connect_group_to_effect);
    ClassDB::bind_method(D_METHOD("get_actual_buffer_size"), &ShinobuGodot::get_actual_buffer_size);
	ClassDB::bind_method(D_METHOD("instantiate_pitch_shift"), &ShinobuGodot::instantiate_pitch_shift);
	ClassDB::bind_method(D_METHOD("connect_effect_to_endpoint", "effect"), &ShinobuGodot::connect_effect_to_endpoint);
	ClassDB::bind_method(D_METHOD("connect_effect_to_group", "effect", "group"), &ShinobuGodot::connect_effect_to_group);
	ClassDB::bind_method(D_METHOD("connect_group_to_endpoint", "group_name"), &ShinobuGodot::connect_group_to_endpoint);
	ClassDB::bind_method(D_METHOD("get_current_backend_name"), &ShinobuGodot::get_current_backend_name);

}

uint64_t ShinobuGodot::get_dsp_time() const {
    return shinobu->get_dsp_time();
}

void ShinobuGodot::set_dsp_time(uint64_t m_new_time_msec) {
    shinobu->set_dsp_time(m_new_time_msec);
}

int64_t ShinobuGodot::register_group(String m_group_name, String m_parent_group_name) {
    return shinobu->register_group(m_group_name.utf8().get_data(), m_parent_group_name.utf8().get_data());
}

void ShinobuGodot::unregister_sound(String m_sound_name) {
    return shinobu->unregister_sound(m_sound_name.utf8().get_data());
}

Error ShinobuGodot::register_sound_from_path(String m_path, String m_sound_name) {
    Ref<ShinobuGodotAudioFile> audio_file = Ref<ShinobuGodotAudioFile>(memnew(ShinobuGodotAudioFile));
    Error err = audio_file->load_from_file(m_path);
    if (err == OK) {
        if (register_sound(audio_file, m_sound_name) != SH_SUCCESS) {
            return ERR_BUG;
        }
    }
    return err;
}

int64_t ShinobuGodot::register_sound(Ref<ShinobuGodotAudioFile> audio_file, String m_sound_name) {
    std::string sound_name_str = std::string(m_sound_name.utf8().get_data());
    return shinobu->register_sound_from_memory(sound_name_str, audio_file->ptr(), audio_file->get_size());
}

Ref<ShinobuGodotSoundPlayback> ShinobuGodot::instantiate_sound(String sound_name, String group_name, bool use_source_channel_count) {
    std::unique_ptr<ShinobuSoundPlayback> playback = shinobu->instantiate_sound(sound_name.utf8().get_data(), group_name.utf8().get_data(), use_source_channel_count);
    ShinobuGodotSoundPlayback* godot_playback = memnew(ShinobuGodotSoundPlayback(std::move(playback)));
    Ref<ShinobuGodotSoundPlayback> out(godot_playback);
    return out;
}

int64_t ShinobuGodot::fire_and_forget_sound(String sound_name, String group_name) {
    return shinobu->fire_and_forget_sound(sound_name.utf8().get_data(), group_name.utf8().get_data());
}

void ShinobuGodot::set_group_volume(String name, float linear_volume) {
    shinobu->set_group_volume(name.utf8().get_data(), linear_volume);
}

float ShinobuGodot::get_group_volume(String name) {
    return shinobu->get_group_volume(name.utf8().get_data());
}

int64_t ShinobuGodot::set_master_volume(float linear_volume) {
    return shinobu->set_master_volume(linear_volume);
}

float ShinobuGodot::get_master_volume() {
    return shinobu->get_master_volume();
}

uint64_t ShinobuGodot::get_buffer_size() const {
    return shinobu->get_buffer_size();
}

void ShinobuGodot::set_buffer_size(uint64_t m_buffer_size) {
    return shinobu->set_buffer_size(m_buffer_size);
}

Ref<ShinobuGodotEffectSpectrumAnalyzer> ShinobuGodot::instantiate_spectrum_analyzer() {
    std::unique_ptr<ShinobuSpectrumAnalyzer> analyzer = std::make_unique<ShinobuSpectrumAnalyzer>(shinobu->get_engine());
    analyzer->initialize(2);
    analyzer->connect_to_node(ma_engine_get_endpoint(shinobu->get_engine()));
    ShinobuGodotEffectSpectrumAnalyzer* godot_analyzer = memnew(ShinobuGodotEffectSpectrumAnalyzer(std::move(analyzer)));
    Ref<ShinobuGodotEffectSpectrumAnalyzer> out(godot_analyzer);
    return out;
}

Ref<ShinobuGodotEffectPitchShift> ShinobuGodot::instantiate_pitch_shift() {
    std::unique_ptr<ShinobuPitchShift> pitch_shift = std::make_unique<ShinobuPitchShift>(shinobu->get_engine());
    pitch_shift->initialize(2);
    pitch_shift->connect_to_node(ma_engine_get_endpoint(shinobu->get_engine()));
    ShinobuGodotEffectPitchShift* godot_pitch_shift = memnew(ShinobuGodotEffectPitchShift(std::move(pitch_shift)));
    Ref<ShinobuGodotEffectPitchShift> out(godot_pitch_shift);
    return out;
}

Ref<ShinobuGodotEffectChannelRemap> ShinobuGodot::instantiate_channel_remap(uint32_t channel_count_in, uint32_t channel_count_out) {
    std::unique_ptr<ShinobuChannelRemap> channel_remap = std::make_unique<ShinobuChannelRemap>(shinobu->get_engine());
    channel_remap->initialize(channel_count_in, channel_count_out);
    channel_remap->connect_to_node(ma_engine_get_endpoint(shinobu->get_engine()));
    ShinobuGodotEffectChannelRemap* godot_channel_remap = memnew(ShinobuGodotEffectChannelRemap(std::move(channel_remap)));
    Ref<ShinobuGodotEffectChannelRemap> out(godot_channel_remap);
    return out;
}

uint64_t ShinobuGodot::connect_group_to_effect(String m_group_name, Ref<ShinobuGodotEffect> m_effect) {
    return shinobu->connect_group_to_effect(m_group_name.utf8().get_data(), m_effect->get_effect());
}

uint64_t ShinobuGodot::get_actual_buffer_size() const {
    return shinobu->get_actual_buffer_size();
}

int64_t ShinobuGodot::connect_effect_to_endpoint(Ref<ShinobuGodotEffect> m_effect) {
    return m_effect->get_effect()->connect_to_node(ma_engine_get_endpoint(shinobu->get_engine()));
}

int64_t ShinobuGodot::connect_effect_to_group(Ref<ShinobuGodotEffect> m_effect, String m_group_name) {
    return shinobu->connect_effect_to_group(m_effect->get_effect(), m_group_name.utf8().get_data());
}

int64_t ShinobuGodot::connect_group_to_endpoint(String m_group_name) {
    return shinobu->connect_group_to_endpoint(m_group_name.utf8().get_data());
}

ma_backend ShinobuGodot::string_to_backend(String str) {
    str = str.to_lower();
    if (str == "wasapi") {
        return ma_backend_wasapi;
    } else if (str == "directsound") {
        return ma_backend_dsound;
    } else if (str == "winmm") {
        return ma_backend_winmm;
    } else if (str == "coreaudio") {
        return ma_backend_coreaudio;
    } else if (str == "sndio") {
        return ma_backend_sndio;
    } else if (str == "audio4") {
        return ma_backend_audio4;
    } else if (str == "oss") {
        return ma_backend_oss;
    } else if (str == "pulseaudio") {
        return ma_backend_pulseaudio;
    } else if (str == "alsa") {
        return ma_backend_alsa;
    } else if (str == "jack") {
        return ma_backend_jack;
    } else if (str == "aaudio") {
        return ma_backend_aaudio;
    } else if (str == "opensl") {
        return ma_backend_opensl;
    } else if (str == "webaudio") {
        return ma_backend_webaudio;
    }
    return ma_backend_null;
}

uint64_t ShinobuGodot::initialize() {
    List<String> args = OS::get_singleton()->get_cmdline_args();
    ma_backend backend_to_force = ma_backend_null;

    #ifdef X11_ENABLED
    // PipeWire on deck sucks, lets check if we are on a deck and force alsa by default
    String deck_variable = OS::get_singleton()->get_environment("SteamDeck");
    if (!deck_variable.empty() && deck_variable.to_int64() > 0) {
        backend_to_force = ma_backend_alsa;
    }
    #endif

    for (int i = 0; i < args.size()-1; i++) {
        if (args[i] == "--shinobu-backend") {
            backend_to_force = string_to_backend(args[i+1]);
        }
    }
    
    return shinobu->initialize(backend_to_force);
}

String ShinobuGodot::get_current_backend_name() const {
    return String(shinobu->get_current_backend_name().c_str());
}

ShinobuGodot::ShinobuGodot() {
    singleton = this;
    shinobu = memnew(ShinobuAudio);
}

ShinobuGodot::~ShinobuGodot() {
    memdelete(shinobu);
}