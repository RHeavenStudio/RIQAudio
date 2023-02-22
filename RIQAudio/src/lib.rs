use miniaudio::{Context, DataConverter, Device, DeviceConfig, DeviceType, Format};

pub struct AudioStream<'a> {
    /*
        ma_engine* engine;
        ma_resource_manager* resource_manager;
    */
    pub device: &'a Device,
    pub context: &'a Context,
}

pub struct RiqAudioBuffer<'a> {
    pub converter: DataConverter,
    pub processor: &'a RiqAudioProcessor<'a>,
    pub volume: f32,
    pub pitch: f32,
    pub pan: f32,

    pub playing: bool,
    pub paused: bool,
    pub looping: bool,

    pub using: i32,

    pub next: &'a RiqAudioBuffer<'a>,
    pub prev: &'a RiqAudioBuffer<'a>,
}

pub struct RiqAudioProcessor<'a> {
    /*
    AudioCallback process;
     */
    // pub process: Fn<>
    pub next: Option<&'a RiqAudioProcessor<'a>>,
    pub prev: Option<&'a RiqAudioProcessor<'a>>,
}

pub struct AudioSystem {
    pub device: Device,
    pub is_ready: bool,
    pub pcm_buffer_size: usize,
    pub pcm_buffer: Vec<u8>,
}

pub struct AudioBuffer<'a> {
    pub first: Option<&'a RiqAudioBuffer<'a>>,
    pub last: Option<&'a RiqAudioBuffer<'a>>,
    pub default_size: i32,
}

pub struct AudioMultiChannel<'a> {
    pub pool_counter: u32,
    pub pool: Vec<&'a RiqAudioBuffer<'a>>,
    pub channels: Vec<u32>,
}

pub struct AudioData<'a> {
    pub system: AudioSystem,
    pub buffer: AudioBuffer<'a>,
    pub multi_channel: AudioMultiChannel<'a>,
}

// mut
pub static mut AUDIO: Option<AudioData> = None;

#[no_mangle]
pub extern "C" fn riq_init_audio_device() {
    let mut config = DeviceConfig::new(DeviceType::Playback);
    config.playback_mut().set_device_id(None);
    config.playback_mut().set_format(Format::F32);
    config.playback_mut().set_channels(2);

    config.capture_mut().set_device_id(None);
    config.capture_mut().set_format(Format::S16);
    config.capture_mut().set_channels(1);
    config.set_sample_rate(0);

    let device = Device::new(None, &config).expect("failed to open playback device");

    // why am i so bad at rust
    unsafe {
        AUDIO = Some(AudioData {
            system: AudioSystem {
                device,
                is_ready: true,
                pcm_buffer_size: 0,
                pcm_buffer: Vec::new(),
            },
            buffer: AudioBuffer {
                first: None,
                last: None,
                default_size: 0,
            },
            multi_channel: AudioMultiChannel {
                pool_counter: 0,
                pool: Vec::new(),
                channels: Vec::new(),
            },
        });
    }
}

#[no_mangle]
pub extern "C" fn riq_is_ready() -> bool {
    // why am i so bad at rust
    unsafe {
        if let Some(audio) = &mut AUDIO {
            return audio.system.is_ready;
        }
    }

    false
}

#[no_mangle]
pub extern "C" fn riq_close_audio_device() {
    // why am i so bad at rust
    unsafe {
        if let Some(audio) = &mut AUDIO {
            audio.system.device.stop().unwrap();
            audio.system.pcm_buffer.clear();
        }
    }
}
