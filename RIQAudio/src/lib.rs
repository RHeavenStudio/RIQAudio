use miniaudio::{Device, DeviceConfig, DeviceType};

#[no_mangle]
pub extern fn rig_init_audio_device() {
    let mut config = DeviceConfig::new(DeviceType::Playback);
    config.playback_mut().set_format(miniaudio::Format::F32);
    config.playback_mut().set_channels(2);
    config.set_sample_rate(0);

    config.capture_mut().set_channels(1);
    config.capture_mut().set_format(miniaudio::Format::S16);

    config.set_stop_callback(|_device| {
        println!("Device Stopped.");
    });

    let mut device = Device::new(None, &config).expect("failed to open playback device");

    device.set_data_callback(move |_device, _output, _frames| {});

    device.start().expect("failed to start device");
}
