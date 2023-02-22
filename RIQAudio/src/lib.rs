use miniaudio::{Context, DataConverter, Device, Decoder, DeviceConfig, DeviceType, Format};
use std::sync::Mutex;

use libc::c_char;
use std::ffi::CStr;

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

static AUDIO: Mutex<Option<AudioData>> = Mutex::new(None);

#[no_mangle]
pub extern "C" fn riq_init_audio_device(file: *const c_char) {   
    let c_str = unsafe {
        CStr::from_ptr(file)
    };
    
    let file_path = c_str.to_str().unwrap();
    println!("{}", file_path.to_string());
    let mut decoder = Decoder::from_file(file_path.to_string(), None).unwrap();

    let mut config = DeviceConfig::new(DeviceType::Playback);
    config.playback_mut().set_device_id(None);
    config.playback_mut().set_format(Format::F32);
    config.playback_mut().set_channels(2);

    config.capture_mut().set_device_id(None);
    config.capture_mut().set_format(Format::S16);
    config.capture_mut().set_channels(1);
    config.set_sample_rate(0);

    let mut device = Device::new(None, &config).expect("failed to open playback device");

    device.set_data_callback(move |_device, output, _frames| {
        decoder.read_pcm_frames(output);
    });

    device.start().expect("Failed to start device!");

    AUDIO.lock().unwrap().replace(AudioData {
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

#[no_mangle]
pub extern "C" fn riq_is_ready() -> bool {
    let audio_data = AUDIO.lock().unwrap().take();

    if audio_data.is_some() {
        return audio_data.unwrap().system.is_ready;
    }

    false
}

#[no_mangle]
pub extern "C" fn riq_close_audio_device() {
    let mut audio_data = AUDIO.lock().unwrap().take();

    if let Some(audio) = &mut audio_data {
        audio.system.device.stop().unwrap();
        audio.system.pcm_buffer.clear();
    }

    println!("Closed audio device!");
}
