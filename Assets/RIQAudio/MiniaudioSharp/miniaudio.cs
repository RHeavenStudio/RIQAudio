using System;
using System.Runtime.InteropServices;
using static MiniaudioSharp.ma_format;

namespace MiniaudioSharp
{

    public enum ma_log_level
    {
        MA_LOG_LEVEL_DEBUG = 4,
        MA_LOG_LEVEL_INFO = 3,
        MA_LOG_LEVEL_WARNING = 2,
        MA_LOG_LEVEL_ERROR = 1,
    }

    public enum _ma_channel_position
    {
        MA_CHANNEL_NONE = 0,
        MA_CHANNEL_MONO = 1,
        MA_CHANNEL_FRONT_LEFT = 2,
        MA_CHANNEL_FRONT_RIGHT = 3,
        MA_CHANNEL_FRONT_CENTER = 4,
        MA_CHANNEL_LFE = 5,
        MA_CHANNEL_BACK_LEFT = 6,
        MA_CHANNEL_BACK_RIGHT = 7,
        MA_CHANNEL_FRONT_LEFT_CENTER = 8,
        MA_CHANNEL_FRONT_RIGHT_CENTER = 9,
        MA_CHANNEL_BACK_CENTER = 10,
        MA_CHANNEL_SIDE_LEFT = 11,
        MA_CHANNEL_SIDE_RIGHT = 12,
        MA_CHANNEL_TOP_CENTER = 13,
        MA_CHANNEL_TOP_FRONT_LEFT = 14,
        MA_CHANNEL_TOP_FRONT_CENTER = 15,
        MA_CHANNEL_TOP_FRONT_RIGHT = 16,
        MA_CHANNEL_TOP_BACK_LEFT = 17,
        MA_CHANNEL_TOP_BACK_CENTER = 18,
        MA_CHANNEL_TOP_BACK_RIGHT = 19,
        MA_CHANNEL_AUX_0 = 20,
        MA_CHANNEL_AUX_1 = 21,
        MA_CHANNEL_AUX_2 = 22,
        MA_CHANNEL_AUX_3 = 23,
        MA_CHANNEL_AUX_4 = 24,
        MA_CHANNEL_AUX_5 = 25,
        MA_CHANNEL_AUX_6 = 26,
        MA_CHANNEL_AUX_7 = 27,
        MA_CHANNEL_AUX_8 = 28,
        MA_CHANNEL_AUX_9 = 29,
        MA_CHANNEL_AUX_10 = 30,
        MA_CHANNEL_AUX_11 = 31,
        MA_CHANNEL_AUX_12 = 32,
        MA_CHANNEL_AUX_13 = 33,
        MA_CHANNEL_AUX_14 = 34,
        MA_CHANNEL_AUX_15 = 35,
        MA_CHANNEL_AUX_16 = 36,
        MA_CHANNEL_AUX_17 = 37,
        MA_CHANNEL_AUX_18 = 38,
        MA_CHANNEL_AUX_19 = 39,
        MA_CHANNEL_AUX_20 = 40,
        MA_CHANNEL_AUX_21 = 41,
        MA_CHANNEL_AUX_22 = 42,
        MA_CHANNEL_AUX_23 = 43,
        MA_CHANNEL_AUX_24 = 44,
        MA_CHANNEL_AUX_25 = 45,
        MA_CHANNEL_AUX_26 = 46,
        MA_CHANNEL_AUX_27 = 47,
        MA_CHANNEL_AUX_28 = 48,
        MA_CHANNEL_AUX_29 = 49,
        MA_CHANNEL_AUX_30 = 50,
        MA_CHANNEL_AUX_31 = 51,
        MA_CHANNEL_LEFT = MA_CHANNEL_FRONT_LEFT,
        MA_CHANNEL_RIGHT = MA_CHANNEL_FRONT_RIGHT,
        MA_CHANNEL_POSITION_COUNT = (MA_CHANNEL_AUX_31 + 1),
    }

    public enum ma_result
    {
        MA_SUCCESS = 0,
        MA_ERROR = -1,
        MA_INVALID_ARGS = -2,
        MA_INVALID_OPERATION = -3,
        MA_OUT_OF_MEMORY = -4,
        MA_OUT_OF_RANGE = -5,
        MA_ACCESS_DENIED = -6,
        MA_DOES_NOT_EXIST = -7,
        MA_ALREADY_EXISTS = -8,
        MA_TOO_MANY_OPEN_FILES = -9,
        MA_INVALID_FILE = -10,
        MA_TOO_BIG = -11,
        MA_PATH_TOO_LONG = -12,
        MA_NAME_TOO_LONG = -13,
        MA_NOT_DIRECTORY = -14,
        MA_IS_DIRECTORY = -15,
        MA_DIRECTORY_NOT_EMPTY = -16,
        MA_AT_END = -17,
        MA_NO_SPACE = -18,
        MA_BUSY = -19,
        MA_IO_ERROR = -20,
        MA_INTERRUPT = -21,
        MA_UNAVAILABLE = -22,
        MA_ALREADY_IN_USE = -23,
        MA_BAD_ADDRESS = -24,
        MA_BAD_SEEK = -25,
        MA_BAD_PIPE = -26,
        MA_DEADLOCK = -27,
        MA_TOO_MANY_LINKS = -28,
        MA_NOT_IMPLEMENTED = -29,
        MA_NO_MESSAGE = -30,
        MA_BAD_MESSAGE = -31,
        MA_NO_DATA_AVAILABLE = -32,
        MA_INVALID_DATA = -33,
        MA_TIMEOUT = -34,
        MA_NO_NETWORK = -35,
        MA_NOT_UNIQUE = -36,
        MA_NOT_SOCKET = -37,
        MA_NO_ADDRESS = -38,
        MA_BAD_PROTOCOL = -39,
        MA_PROTOCOL_UNAVAILABLE = -40,
        MA_PROTOCOL_NOT_SUPPORTED = -41,
        MA_PROTOCOL_FAMILY_NOT_SUPPORTED = -42,
        MA_ADDRESS_FAMILY_NOT_SUPPORTED = -43,
        MA_SOCKET_NOT_SUPPORTED = -44,
        MA_CONNECTION_RESET = -45,
        MA_ALREADY_CONNECTED = -46,
        MA_NOT_CONNECTED = -47,
        MA_CONNECTION_REFUSED = -48,
        MA_NO_HOST = -49,
        MA_IN_PROGRESS = -50,
        MA_CANCELLED = -51,
        MA_MEMORY_ALREADY_MAPPED = -52,
        MA_FORMAT_NOT_SUPPORTED = -100,
        MA_DEVICE_TYPE_NOT_SUPPORTED = -101,
        MA_SHARE_MODE_NOT_SUPPORTED = -102,
        MA_NO_BACKEND = -103,
        MA_NO_DEVICE = -104,
        MA_API_NOT_FOUND = -105,
        MA_INVALID_DEVICE_CONFIG = -106,
        MA_LOOP = -107,
        MA_DEVICE_NOT_INITIALIZED = -200,
        MA_DEVICE_ALREADY_INITIALIZED = -201,
        MA_DEVICE_NOT_STARTED = -202,
        MA_DEVICE_NOT_STOPPED = -203,
        MA_FAILED_TO_INIT_BACKEND = -300,
        MA_FAILED_TO_OPEN_BACKEND_DEVICE = -301,
        MA_FAILED_TO_START_BACKEND_DEVICE = -302,
        MA_FAILED_TO_STOP_BACKEND_DEVICE = -303,
    }

    public enum ma_stream_format
    {
        ma_stream_format_pcm = 0,
    }

    public enum ma_stream_layout
    {
        ma_stream_layout_interleaved = 0,
        ma_stream_layout_deinterleaved,
    }

    public enum ma_dither_mode
    {
        ma_dither_mode_none = 0,
        ma_dither_mode_rectangle,
        ma_dither_mode_triangle,
    }

    public enum ma_format
    {
        ma_format_unknown = 0,
        ma_format_u8 = 1,
        ma_format_s16 = 2,
        ma_format_s24 = 3,
        ma_format_s32 = 4,
        ma_format_f32 = 5,
        ma_format_count,
    }

    public enum ma_standard_sample_rate
    {
        ma_standard_sample_rate_48000 = 48000,
        ma_standard_sample_rate_44100 = 44100,
        ma_standard_sample_rate_32000 = 32000,
        ma_standard_sample_rate_24000 = 24000,
        ma_standard_sample_rate_22050 = 22050,
        ma_standard_sample_rate_88200 = 88200,
        ma_standard_sample_rate_96000 = 96000,
        ma_standard_sample_rate_176400 = 176400,
        ma_standard_sample_rate_192000 = 192000,
        ma_standard_sample_rate_16000 = 16000,
        ma_standard_sample_rate_11025 = 11250,
        ma_standard_sample_rate_8000 = 8000,
        ma_standard_sample_rate_352800 = 352800,
        ma_standard_sample_rate_384000 = 384000,
        ma_standard_sample_rate_min = ma_standard_sample_rate_8000,
        ma_standard_sample_rate_max = ma_standard_sample_rate_384000,
        ma_standard_sample_rate_count = 14,
    }

    public enum ma_channel_mix_mode
    {
        ma_channel_mix_mode_rectangular = 0,
        ma_channel_mix_mode_simple,
        ma_channel_mix_mode_custom_weights,
        ma_channel_mix_mode_default = ma_channel_mix_mode_rectangular,
    }

    public enum ma_standard_channel_map
    {
        ma_standard_channel_map_microsoft,
        ma_standard_channel_map_alsa,
        ma_standard_channel_map_rfc3551,
        ma_standard_channel_map_flac,
        ma_standard_channel_map_vorbis,
        ma_standard_channel_map_sound4,
        ma_standard_channel_map_sndio,
        ma_standard_channel_map_webaudio = ma_standard_channel_map_flac,
        ma_standard_channel_map_default = ma_standard_channel_map_microsoft,
    }

    public enum ma_performance_profile
    {
        ma_performance_profile_low_latency = 0,
        ma_performance_profile_conservative,
    }

    public unsafe partial struct ma_allocation_callbacks
    {
        public void* pUserData;

        [NativeTypeName("void *(*)(size_t, void *)")]
        public delegate* unmanaged[Cdecl]<nuint, void*, void*> onMalloc;

        [NativeTypeName("void *(*)(void *, size_t, void *)")]
        public delegate* unmanaged[Cdecl]<void*, nuint, void*, void*> onRealloc;

        [NativeTypeName("void (*)(void *, void *)")]
        public delegate* unmanaged[Cdecl]<void*, void*, void> onFree;
    }

    public partial struct ma_lcg
    {
        [NativeTypeName("ma_int32")]
        public int state;
    }

    public enum ma_thread_priority
    {
        ma_thread_priority_idle = -5,
        ma_thread_priority_lowest = -4,
        ma_thread_priority_low = -3,
        ma_thread_priority_normal = -2,
        ma_thread_priority_high = -1,
        ma_thread_priority_highest = 0,
        ma_thread_priority_realtime = 1,
        ma_thread_priority_default = 0,
    }

    public unsafe partial struct ma_log_callback
    {
        [NativeTypeName("ma_log_callback_proc")]
        public delegate* unmanaged[Cdecl]<void*, uint, sbyte*, void> onLog;

        public void* pUserData;
    }

    public unsafe partial struct ma_log
    {
        [NativeTypeName("ma_log_callback [4]")]
        public _callbacks_e__FixedBuffer callbacks;

        [NativeTypeName("ma_uint32")]
        public uint callbackCount;

        public ma_allocation_callbacks allocationCallbacks;

        [NativeTypeName("ma_mutex")]
        public void* @lock;

        public partial struct _callbacks_e__FixedBuffer
        {
            public ma_log_callback e0;
            public ma_log_callback e1;
            public ma_log_callback e2;
            public ma_log_callback e3;

            public ref ma_log_callback this[int index]
            {
                get
                {
                    return ref AsSpan()[index];
                }
            }

            public Span<ma_log_callback> AsSpan() => MemoryMarshal.CreateSpan(ref e0, 4);
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct ma_biquad_coefficient
    {
        [FieldOffset(0)]
        public float f32;

        [FieldOffset(0)]
        [NativeTypeName("ma_int32")]
        public int s32;
    }

    public partial struct ma_biquad_config
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        public double b0;

        public double b1;

        public double b2;

        public double a0;

        public double a1;

        public double a2;
    }

    public unsafe partial struct ma_biquad
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        public ma_biquad_coefficient b0;

        public ma_biquad_coefficient b1;

        public ma_biquad_coefficient b2;

        public ma_biquad_coefficient a1;

        public ma_biquad_coefficient a2;

        public ma_biquad_coefficient* pR1;

        public ma_biquad_coefficient* pR2;

        public void* _pHeap;

        [NativeTypeName("ma_bool32")]
        public uint _ownsHeap;
    }

    public partial struct ma_lpf1_config
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        public double cutoffFrequency;

        public double q;
    }

    public unsafe partial struct ma_lpf1
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        public ma_biquad_coefficient a;

        public ma_biquad_coefficient* pR1;

        public void* _pHeap;

        [NativeTypeName("ma_bool32")]
        public uint _ownsHeap;
    }

    public partial struct ma_lpf2
    {
        public ma_biquad bq;
    }

    public partial struct ma_lpf_config
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        public double cutoffFrequency;

        [NativeTypeName("ma_uint32")]
        public uint order;
    }

    public unsafe partial struct ma_lpf
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        [NativeTypeName("ma_uint32")]
        public uint lpf1Count;

        [NativeTypeName("ma_uint32")]
        public uint lpf2Count;

        public ma_lpf1* pLPF1;

        public ma_lpf2* pLPF2;

        public void* _pHeap;

        [NativeTypeName("ma_bool32")]
        public uint _ownsHeap;
    }

    public partial struct ma_hpf1_config
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        public double cutoffFrequency;

        public double q;
    }

    public unsafe partial struct ma_hpf1
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        public ma_biquad_coefficient a;

        public ma_biquad_coefficient* pR1;

        public void* _pHeap;

        [NativeTypeName("ma_bool32")]
        public uint _ownsHeap;
    }

    public partial struct ma_hpf2
    {
        public ma_biquad bq;
    }

    public partial struct ma_hpf_config
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        public double cutoffFrequency;

        [NativeTypeName("ma_uint32")]
        public uint order;
    }

    public unsafe partial struct ma_hpf
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        [NativeTypeName("ma_uint32")]
        public uint hpf1Count;

        [NativeTypeName("ma_uint32")]
        public uint hpf2Count;

        public ma_hpf1* pHPF1;

        public ma_hpf2* pHPF2;

        public void* _pHeap;

        [NativeTypeName("ma_bool32")]
        public uint _ownsHeap;
    }

    public partial struct ma_bpf2_config
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        public double cutoffFrequency;

        public double q;
    }

    public partial struct ma_bpf2
    {
        public ma_biquad bq;
    }

    public partial struct ma_bpf_config
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        public double cutoffFrequency;

        [NativeTypeName("ma_uint32")]
        public uint order;
    }

    public unsafe partial struct ma_bpf
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint bpf2Count;

        public ma_bpf2* pBPF2;

        public void* _pHeap;

        [NativeTypeName("ma_bool32")]
        public uint _ownsHeap;
    }

    public partial struct ma_notch2_config
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        public double q;

        public double frequency;
    }

    public partial struct ma_notch2
    {
        public ma_biquad bq;
    }

    public partial struct ma_peak2_config
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        public double gainDB;

        public double q;

        public double frequency;
    }

    public partial struct ma_peak2
    {
        public ma_biquad bq;
    }

    public partial struct ma_loshelf2_config
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        public double gainDB;

        public double shelfSlope;

        public double frequency;
    }

    public partial struct ma_loshelf2
    {
        public ma_biquad bq;
    }

    public partial struct ma_hishelf2_config
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        public double gainDB;

        public double shelfSlope;

        public double frequency;
    }

    public partial struct ma_hishelf2
    {
        public ma_biquad bq;
    }

    public partial struct ma_delay_config
    {
        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        [NativeTypeName("ma_uint32")]
        public uint delayInFrames;

        [NativeTypeName("ma_bool32")]
        public uint delayStart;

        public float wet;

        public float dry;

        public float decay;
    }

    public unsafe partial struct ma_delay
    {
        public ma_delay_config config;

        [NativeTypeName("ma_uint32")]
        public uint cursor;

        [NativeTypeName("ma_uint32")]
        public uint bufferSizeInFrames;

        public float* pBuffer;
    }

    public partial struct ma_gainer_config
    {
        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint smoothTimeInFrames;
    }

    public unsafe partial struct ma_gainer
    {
        public ma_gainer_config config;

        [NativeTypeName("ma_uint32")]
        public uint t;

        public float* pOldGains;

        public float* pNewGains;

        public void* _pHeap;

        [NativeTypeName("ma_bool32")]
        public uint _ownsHeap;
    }

    public enum ma_pan_mode
    {
        ma_pan_mode_balance = 0,
        ma_pan_mode_pan,
    }

    public partial struct ma_panner_config
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        public ma_pan_mode mode;

        public float pan;
    }

    public partial struct ma_panner
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        public ma_pan_mode mode;

        public float pan;
    }

    public partial struct ma_fader_config
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;
    }

    public partial struct ma_fader
    {
        public ma_fader_config config;

        public float volumeBeg;

        public float volumeEnd;

        [NativeTypeName("ma_uint64")]
        public ulong lengthInFrames;

        [NativeTypeName("ma_uint64")]
        public ulong cursorInFrames;
    }

    public partial struct ma_vec3f
    {
        public float x;

        public float y;

        public float z;
    }

    public enum ma_attenuation_model
    {
        ma_attenuation_model_none,
        ma_attenuation_model_inverse,
        ma_attenuation_model_linear,
        ma_attenuation_model_exponential,
    }

    public enum ma_positioning
    {
        ma_positioning_absolute,
        ma_positioning_relative,
    }

    public enum ma_handedness
    {
        ma_handedness_right,
        ma_handedness_left,
    }

    public unsafe partial struct ma_spatializer_listener_config
    {
        [NativeTypeName("ma_uint32")]
        public uint channelsOut;

        [NativeTypeName("ma_channel *")]
        public byte* pChannelMapOut;

        public ma_handedness handedness;

        public float coneInnerAngleInRadians;

        public float coneOuterAngleInRadians;

        public float coneOuterGain;

        public float speedOfSound;

        public ma_vec3f worldUp;
    }

    public unsafe partial struct ma_spatializer_listener
    {
        public ma_spatializer_listener_config config;

        public ma_vec3f position;

        public ma_vec3f direction;

        public ma_vec3f velocity;

        [NativeTypeName("ma_bool32")]
        public uint isEnabled;

        [NativeTypeName("ma_bool32")]
        public uint _ownsHeap;

        public void* _pHeap;
    }

    public unsafe partial struct ma_spatializer_config
    {
        [NativeTypeName("ma_uint32")]
        public uint channelsIn;

        [NativeTypeName("ma_uint32")]
        public uint channelsOut;

        [NativeTypeName("ma_channel *")]
        public byte* pChannelMapIn;

        public ma_attenuation_model attenuationModel;

        public ma_positioning positioning;

        public ma_handedness handedness;

        public float minGain;

        public float maxGain;

        public float minDistance;

        public float maxDistance;

        public float rolloff;

        public float coneInnerAngleInRadians;

        public float coneOuterAngleInRadians;

        public float coneOuterGain;

        public float dopplerFactor;

        public float directionalAttenuationFactor;

        [NativeTypeName("ma_uint32")]
        public uint gainSmoothTimeInFrames;
    }

    public unsafe partial struct ma_spatializer
    {
        [NativeTypeName("ma_uint32")]
        public uint channelsIn;

        [NativeTypeName("ma_uint32")]
        public uint channelsOut;

        [NativeTypeName("ma_channel *")]
        public byte* pChannelMapIn;

        public ma_attenuation_model attenuationModel;

        public ma_positioning positioning;

        public ma_handedness handedness;

        public float minGain;

        public float maxGain;

        public float minDistance;

        public float maxDistance;

        public float rolloff;

        public float coneInnerAngleInRadians;

        public float coneOuterAngleInRadians;

        public float coneOuterGain;

        public float dopplerFactor;

        public float directionalAttenuationFactor;

        [NativeTypeName("ma_uint32")]
        public uint gainSmoothTimeInFrames;

        public ma_vec3f position;

        public ma_vec3f direction;

        public ma_vec3f velocity;

        public float dopplerPitch;

        public ma_gainer gainer;

        public float* pNewChannelGainsOut;

        public void* _pHeap;

        [NativeTypeName("ma_bool32")]
        public uint _ownsHeap;
    }

    public partial struct ma_linear_resampler_config
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRateIn;

        [NativeTypeName("ma_uint32")]
        public uint sampleRateOut;

        [NativeTypeName("ma_uint32")]
        public uint lpfOrder;

        public double lpfNyquistFactor;
    }

    public unsafe partial struct ma_linear_resampler
    {
        public ma_linear_resampler_config config;

        [NativeTypeName("ma_uint32")]
        public uint inAdvanceInt;

        [NativeTypeName("ma_uint32")]
        public uint inAdvanceFrac;

        [NativeTypeName("ma_uint32")]
        public uint inTimeInt;

        [NativeTypeName("ma_uint32")]
        public uint inTimeFrac;

        [NativeTypeName("union (anonymous union at miniaudio/vendor/miniaudio.h:5099:5)")]
        public _x0_e__Union x0;

        [NativeTypeName("union (anonymous union at miniaudio/vendor/miniaudio.h:5104:5)")]
        public _x1_e__Union x1;

        public ma_lpf lpf;

        public void* _pHeap;

        [NativeTypeName("ma_bool32")]
        public uint _ownsHeap;

        [StructLayout(LayoutKind.Explicit)]
        public unsafe partial struct _x0_e__Union
        {
            [FieldOffset(0)]
            public float* f32;

            [FieldOffset(0)]
            [NativeTypeName("ma_int16 *")]
            public short* s16;
        }

        [StructLayout(LayoutKind.Explicit)]
        public unsafe partial struct _x1_e__Union
        {
            [FieldOffset(0)]
            public float* f32;

            [FieldOffset(0)]
            [NativeTypeName("ma_int16 *")]
            public short* s16;
        }
    }

    public unsafe partial struct ma_resampling_backend_vtable
    {
        [NativeTypeName("ma_result (*)(void *, const ma_resampler_config *, size_t *)")]
        public delegate* unmanaged[Cdecl]<void*, ma_resampler_config*, nuint*, ma_result> onGetHeapSize;

        [NativeTypeName("ma_result (*)(void *, const ma_resampler_config *, void *, ma_resampling_backend **)")]
        public delegate* unmanaged[Cdecl]<void*, ma_resampler_config*, void*, void**, ma_result> onInit;

        [NativeTypeName("void (*)(void *, ma_resampling_backend *, const ma_allocation_callbacks *)")]
        public delegate* unmanaged[Cdecl]<void*, void*, ma_allocation_callbacks*, void> onUninit;

        [NativeTypeName("ma_result (*)(void *, ma_resampling_backend *, const void *, ma_uint64 *, void *, ma_uint64 *)")]
        public delegate* unmanaged[Cdecl]<void*, void*, void*, ulong*, void*, ulong*, ma_result> onProcess;

        [NativeTypeName("ma_result (*)(void *, ma_resampling_backend *, ma_uint32, ma_uint32)")]
        public delegate* unmanaged[Cdecl]<void*, void*, uint, uint, ma_result> onSetRate;

        [NativeTypeName("ma_uint64 (*)(void *, const ma_resampling_backend *)")]
        public delegate* unmanaged[Cdecl]<void*, void*, ulong> onGetInputLatency;

        [NativeTypeName("ma_uint64 (*)(void *, const ma_resampling_backend *)")]
        public delegate* unmanaged[Cdecl]<void*, void*, ulong> onGetOutputLatency;

        [NativeTypeName("ma_result (*)(void *, const ma_resampling_backend *, ma_uint64, ma_uint64 *)")]
        public delegate* unmanaged[Cdecl]<void*, void*, ulong, ulong*, ma_result> onGetRequiredInputFrameCount;

        [NativeTypeName("ma_result (*)(void *, const ma_resampling_backend *, ma_uint64, ma_uint64 *)")]
        public delegate* unmanaged[Cdecl]<void*, void*, ulong, ulong*, ma_result> onGetExpectedOutputFrameCount;

        [NativeTypeName("ma_result (*)(void *, ma_resampling_backend *)")]
        public delegate* unmanaged[Cdecl]<void*, void*, ma_result> onReset;
    }

    public enum ma_resample_algorithm
    {
        ma_resample_algorithm_linear = 0,
        ma_resample_algorithm_custom,
    }

    public unsafe partial struct ma_resampler_config
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRateIn;

        [NativeTypeName("ma_uint32")]
        public uint sampleRateOut;

        public ma_resample_algorithm algorithm;

        public ma_resampling_backend_vtable* pBackendVTable;

        public void* pBackendUserData;

        [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:5162:5)")]
        public _linear_e__Struct linear;

        public partial struct _linear_e__Struct
        {
            [NativeTypeName("ma_uint32")]
            public uint lpfOrder;
        }
    }

    public unsafe partial struct ma_resampler
    {
        [NativeTypeName("ma_resampling_backend *")]
        public void* pBackend;

        public ma_resampling_backend_vtable* pBackendVTable;

        public void* pBackendUserData;

        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRateIn;

        [NativeTypeName("ma_uint32")]
        public uint sampleRateOut;

        [NativeTypeName("union (anonymous union at miniaudio/vendor/miniaudio.h:5179:5)")]
        public _state_e__Union state;

        public void* _pHeap;

        [NativeTypeName("ma_bool32")]
        public uint _ownsHeap;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _state_e__Union
        {
            [FieldOffset(0)]
            public ma_linear_resampler linear;
        }
    }

    public enum ma_channel_conversion_path
    {
        ma_channel_conversion_path_unknown,
        ma_channel_conversion_path_passthrough,
        ma_channel_conversion_path_mono_out,
        ma_channel_conversion_path_mono_in,
        ma_channel_conversion_path_shuffle,
        ma_channel_conversion_path_weights,
    }

    public enum ma_mono_expansion_mode
    {
        ma_mono_expansion_mode_duplicate = 0,
        ma_mono_expansion_mode_average,
        ma_mono_expansion_mode_stereo_only,
        ma_mono_expansion_mode_default = ma_mono_expansion_mode_duplicate,
    }

    public unsafe partial struct ma_channel_converter_config
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channelsIn;

        [NativeTypeName("ma_uint32")]
        public uint channelsOut;

        [NativeTypeName("const ma_channel *")]
        public byte* pChannelMapIn;

        [NativeTypeName("const ma_channel *")]
        public byte* pChannelMapOut;

        public ma_channel_mix_mode mixingMode;

        [NativeTypeName("ma_bool32")]
        public uint calculateLFEFromSpatialChannels;

        public float** ppWeights;
    }

    public unsafe partial struct ma_channel_converter
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channelsIn;

        [NativeTypeName("ma_uint32")]
        public uint channelsOut;

        public ma_channel_mix_mode mixingMode;

        public ma_channel_conversion_path conversionPath;

        [NativeTypeName("ma_channel *")]
        public byte* pChannelMapIn;

        [NativeTypeName("ma_channel *")]
        public byte* pChannelMapOut;

        [NativeTypeName("ma_uint8 *")]
        public byte* pShuffleTable;

        [NativeTypeName("union (anonymous union at miniaudio/vendor/miniaudio.h:5317:5)")]
        public _weights_e__Union weights;

        public void* _pHeap;

        [NativeTypeName("ma_bool32")]
        public uint _ownsHeap;

        [StructLayout(LayoutKind.Explicit)]
        public unsafe partial struct _weights_e__Union
        {
            [FieldOffset(0)]
            public float** f32;

            [FieldOffset(0)]
            [NativeTypeName("ma_int32 **")]
            public int** s16;
        }
    }

    public unsafe partial struct ma_data_converter_config
    {
        public ma_format formatIn;

        public ma_format formatOut;

        [NativeTypeName("ma_uint32")]
        public uint channelsIn;

        [NativeTypeName("ma_uint32")]
        public uint channelsOut;

        [NativeTypeName("ma_uint32")]
        public uint sampleRateIn;

        [NativeTypeName("ma_uint32")]
        public uint sampleRateOut;

        [NativeTypeName("ma_channel *")]
        public byte* pChannelMapIn;

        [NativeTypeName("ma_channel *")]
        public byte* pChannelMapOut;

        public ma_dither_mode ditherMode;

        public ma_channel_mix_mode channelMixMode;

        [NativeTypeName("ma_bool32")]
        public uint calculateLFEFromSpatialChannels;

        public float** ppChannelWeights;

        [NativeTypeName("ma_bool32")]
        public uint allowDynamicSampleRate;

        public ma_resampler_config resampling;
    }

    public enum ma_data_converter_execution_path
    {
        ma_data_converter_execution_path_passthrough,
        ma_data_converter_execution_path_format_only,
        ma_data_converter_execution_path_channels_only,
        ma_data_converter_execution_path_resample_only,
        ma_data_converter_execution_path_resample_first,
        ma_data_converter_execution_path_channels_first,
    }

    public unsafe partial struct ma_data_converter
    {
        public ma_format formatIn;

        public ma_format formatOut;

        [NativeTypeName("ma_uint32")]
        public uint channelsIn;

        [NativeTypeName("ma_uint32")]
        public uint channelsOut;

        [NativeTypeName("ma_uint32")]
        public uint sampleRateIn;

        [NativeTypeName("ma_uint32")]
        public uint sampleRateOut;

        public ma_dither_mode ditherMode;

        public ma_data_converter_execution_path executionPath;

        public ma_channel_converter channelConverter;

        public ma_resampler resampler;

        [NativeTypeName("ma_bool8")]
        public byte hasPreFormatConversion;

        [NativeTypeName("ma_bool8")]
        public byte hasPostFormatConversion;

        [NativeTypeName("ma_bool8")]
        public byte hasChannelConverter;

        [NativeTypeName("ma_bool8")]
        public byte hasResampler;

        [NativeTypeName("ma_bool8")]
        public byte isPassthrough;

        [NativeTypeName("ma_bool8")]
        public byte _ownsHeap;

        public void* _pHeap;
    }

    public unsafe partial struct ma_rb
    {
        public void* pBuffer;

        [NativeTypeName("ma_uint32")]
        public uint subbufferSizeInBytes;

        [NativeTypeName("ma_uint32")]
        public uint subbufferCount;

        [NativeTypeName("ma_uint32")]
        public uint subbufferStrideInBytes;

        [NativeTypeName("ma_uint32")]
        public uint encodedReadOffset;

        [NativeTypeName("ma_uint32")]
        public uint encodedWriteOffset;

        [NativeTypeName("ma_bool8")]
        public byte ownsBuffer;

        [NativeTypeName("ma_bool8")]
        public byte clearOnWriteAcquire;

        public ma_allocation_callbacks allocationCallbacks;
    }

    public partial struct ma_pcm_rb
    {
        public ma_rb rb;

        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;
    }

    public partial struct ma_duplex_rb
    {
        public ma_pcm_rb rb;
    }

    public unsafe partial struct ma_fence
    {
        [NativeTypeName("ma_event")]
        public void* e;

        [NativeTypeName("ma_uint32")]
        public uint counter;
    }

    public unsafe partial struct ma_async_notification_callbacks
    {
        [NativeTypeName("void (*)(ma_async_notification *)")]
        public delegate* unmanaged[Cdecl]<void*, void> onSignal;
    }

    public partial struct ma_async_notification_poll
    {
        public ma_async_notification_callbacks cb;

        [NativeTypeName("ma_bool32")]
        public uint signalled;
    }

    public unsafe partial struct ma_async_notification_event
    {
        public ma_async_notification_callbacks cb;

        [NativeTypeName("ma_event")]
        public void* e;
    }

    public partial struct ma_slot_allocator_config
    {
        [NativeTypeName("ma_uint32")]
        public uint capacity;
    }

    public partial struct ma_slot_allocator_group
    {
        [NativeTypeName("ma_uint32")]
        public uint bitfield;
    }

    public unsafe partial struct ma_slot_allocator
    {
        public ma_slot_allocator_group* pGroups;

        [NativeTypeName("ma_uint32 *")]
        public uint* pSlots;

        [NativeTypeName("ma_uint32")]
        public uint count;

        [NativeTypeName("ma_uint32")]
        public uint capacity;

        [NativeTypeName("ma_bool32")]
        public uint _ownsHeap;

        public void* _pHeap;
    }

    public enum ma_job_type
    {
        MA_JOB_TYPE_QUIT = 0,
        MA_JOB_TYPE_CUSTOM,
        MA_JOB_TYPE_RESOURCE_MANAGER_LOAD_DATA_BUFFER_NODE,
        MA_JOB_TYPE_RESOURCE_MANAGER_FREE_DATA_BUFFER_NODE,
        MA_JOB_TYPE_RESOURCE_MANAGER_PAGE_DATA_BUFFER_NODE,
        MA_JOB_TYPE_RESOURCE_MANAGER_LOAD_DATA_BUFFER,
        MA_JOB_TYPE_RESOURCE_MANAGER_FREE_DATA_BUFFER,
        MA_JOB_TYPE_RESOURCE_MANAGER_LOAD_DATA_STREAM,
        MA_JOB_TYPE_RESOURCE_MANAGER_FREE_DATA_STREAM,
        MA_JOB_TYPE_RESOURCE_MANAGER_PAGE_DATA_STREAM,
        MA_JOB_TYPE_RESOURCE_MANAGER_SEEK_DATA_STREAM,
        MA_JOB_TYPE_DEVICE_AAUDIO_REROUTE,
        MA_JOB_TYPE_COUNT,
    }

    public partial struct ma_job
    {
        [NativeTypeName("union (anonymous union at miniaudio/vendor/miniaudio.h:5965:5)")]
        public _toc_e__Union toc;

        [NativeTypeName("ma_uint64")]
        public ulong next;

        [NativeTypeName("ma_uint32")]
        public uint order;

        [NativeTypeName("union (anonymous union at miniaudio/vendor/miniaudio.h:5978:5)")]
        public _data_e__Union data;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _toc_e__Union
        {
            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:5967:9)")]
            public _breakup_e__Struct breakup;

            [FieldOffset(0)]
            [NativeTypeName("ma_uint64")]
            public ulong allocation;

            public partial struct _breakup_e__Struct
            {
                [NativeTypeName("ma_uint16")]
                public ushort code;

                [NativeTypeName("ma_uint16")]
                public ushort slot;

                [NativeTypeName("ma_uint32")]
                public uint refcount;
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _data_e__Union
        {
            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:5981:9)")]
            public _custom_e__Struct custom;

            [FieldOffset(0)]
            [NativeTypeName("union (anonymous union at miniaudio/vendor/miniaudio.h:5989:9)")]
            public _resourceManager_e__Union resourceManager;

            [FieldOffset(0)]
            [NativeTypeName("union (anonymous union at miniaudio/vendor/miniaudio.h:6067:9)")]
            public _device_e__Union device;

            public unsafe partial struct _custom_e__Struct
            {
                [NativeTypeName("ma_job_proc")]
                public delegate* unmanaged[Cdecl]<ma_job*, ma_result> proc;

                [NativeTypeName("ma_uintptr")]
                public ulong data0;

                [NativeTypeName("ma_uintptr")]
                public ulong data1;
            }

            [StructLayout(LayoutKind.Explicit)]
            public partial struct _resourceManager_e__Union
            {
                [FieldOffset(0)]
                [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:5991:13)")]
                public _loadDataBufferNode_e__Struct loadDataBufferNode;

                [FieldOffset(0)]
                [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6003:13)")]
                public _freeDataBufferNode_e__Struct freeDataBufferNode;

                [FieldOffset(0)]
                [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6010:13)")]
                public _pageDataBufferNode_e__Struct pageDataBufferNode;

                [FieldOffset(0)]
                [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6019:13)")]
                public _loadDataBuffer_e__Struct loadDataBuffer;

                [FieldOffset(0)]
                [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6032:13)")]
                public _freeDataBuffer_e__Struct freeDataBuffer;

                [FieldOffset(0)]
                [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6039:13)")]
                public _loadDataStream_e__Struct loadDataStream;

                [FieldOffset(0)]
                [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6048:13)")]
                public _freeDataStream_e__Struct freeDataStream;

                [FieldOffset(0)]
                [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6054:13)")]
                public _pageDataStream_e__Struct pageDataStream;

                [FieldOffset(0)]
                [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6059:13)")]
                public _seekDataStream_e__Struct seekDataStream;

                public unsafe partial struct _loadDataBufferNode_e__Struct
                {
                    public void* pResourceManager;

                    public void* pDataBufferNode;

                    [NativeTypeName("char *")]
                    public sbyte* pFilePath;

                    [NativeTypeName("wchar_t *")]
                    public ushort* pFilePathW;

                    [NativeTypeName("ma_uint32")]
                    public uint flags;

                    [NativeTypeName("ma_async_notification *")]
                    public void* pInitNotification;

                    [NativeTypeName("ma_async_notification *")]
                    public void* pDoneNotification;

                    public ma_fence* pInitFence;

                    public ma_fence* pDoneFence;
                }

                public unsafe partial struct _freeDataBufferNode_e__Struct
                {
                    public void* pResourceManager;

                    public void* pDataBufferNode;

                    [NativeTypeName("ma_async_notification *")]
                    public void* pDoneNotification;

                    public ma_fence* pDoneFence;
                }

                public unsafe partial struct _pageDataBufferNode_e__Struct
                {
                    public void* pResourceManager;

                    public void* pDataBufferNode;

                    public void* pDecoder;

                    [NativeTypeName("ma_async_notification *")]
                    public void* pDoneNotification;

                    public ma_fence* pDoneFence;
                }

                public unsafe partial struct _loadDataBuffer_e__Struct
                {
                    public void* pDataBuffer;

                    [NativeTypeName("ma_async_notification *")]
                    public void* pInitNotification;

                    [NativeTypeName("ma_async_notification *")]
                    public void* pDoneNotification;

                    public ma_fence* pInitFence;

                    public ma_fence* pDoneFence;

                    [NativeTypeName("ma_uint64")]
                    public ulong rangeBegInPCMFrames;

                    [NativeTypeName("ma_uint64")]
                    public ulong rangeEndInPCMFrames;

                    [NativeTypeName("ma_uint64")]
                    public ulong loopPointBegInPCMFrames;

                    [NativeTypeName("ma_uint64")]
                    public ulong loopPointEndInPCMFrames;

                    [NativeTypeName("ma_uint32")]
                    public uint isLooping;
                }

                public unsafe partial struct _freeDataBuffer_e__Struct
                {
                    public void* pDataBuffer;

                    [NativeTypeName("ma_async_notification *")]
                    public void* pDoneNotification;

                    public ma_fence* pDoneFence;
                }

                public unsafe partial struct _loadDataStream_e__Struct
                {
                    public void* pDataStream;

                    [NativeTypeName("char *")]
                    public sbyte* pFilePath;

                    [NativeTypeName("wchar_t *")]
                    public ushort* pFilePathW;

                    [NativeTypeName("ma_uint64")]
                    public ulong initialSeekPoint;

                    [NativeTypeName("ma_async_notification *")]
                    public void* pInitNotification;

                    public ma_fence* pInitFence;
                }

                public unsafe partial struct _freeDataStream_e__Struct
                {
                    public void* pDataStream;

                    [NativeTypeName("ma_async_notification *")]
                    public void* pDoneNotification;

                    public ma_fence* pDoneFence;
                }

                public unsafe partial struct _pageDataStream_e__Struct
                {
                    public void* pDataStream;

                    [NativeTypeName("ma_uint32")]
                    public uint pageIndex;
                }

                public unsafe partial struct _seekDataStream_e__Struct
                {
                    public void* pDataStream;

                    [NativeTypeName("ma_uint64")]
                    public ulong frameIndex;
                }
            }

            [StructLayout(LayoutKind.Explicit)]
            public partial struct _device_e__Union
            {
                [FieldOffset(0)]
                [NativeTypeName("union (anonymous union at miniaudio/vendor/miniaudio.h:6069:13)")]
                public _aaudio_e__Union aaudio;

                [StructLayout(LayoutKind.Explicit)]
                public partial struct _aaudio_e__Union
                {
                    [FieldOffset(0)]
                    [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6071:17)")]
                    public _reroute_e__Struct reroute;

                    public unsafe partial struct _reroute_e__Struct
                    {
                        public void* pDevice;

                        [NativeTypeName("ma_uint32")]
                        public uint deviceType;
                    }
                }
            }
        }
    }

    public enum ma_job_queue_flags
    {
        MA_JOB_QUEUE_FLAG_NON_BLOCKING = 0x00000001,
    }

    public partial struct ma_job_queue_config
    {
        [NativeTypeName("ma_uint32")]
        public uint flags;

        [NativeTypeName("ma_uint32")]
        public uint capacity;
    }

    public unsafe partial struct ma_job_queue
    {
        [NativeTypeName("ma_uint32")]
        public uint flags;

        [NativeTypeName("ma_uint32")]
        public uint capacity;

        [NativeTypeName("ma_uint64")]
        public ulong head;

        [NativeTypeName("ma_uint64")]
        public ulong tail;

        [NativeTypeName("ma_semaphore")]
        public void* sem;

        public ma_slot_allocator allocator;

        public ma_job* pJobs;

        [NativeTypeName("ma_spinlock")]
        public uint @lock;

        public void* _pHeap;

        [NativeTypeName("ma_bool32")]
        public uint _ownsHeap;
    }

    public enum ma_device_state
    {
        ma_device_state_uninitialized = 0,
        ma_device_state_stopped = 1,
        ma_device_state_started = 2,
        ma_device_state_starting = 3,
        ma_device_state_stopping = 4,
    }

    public unsafe partial struct ma_IMMNotificationClient
    {
        public void* lpVtbl;

        [NativeTypeName("ma_uint32")]
        public uint counter;

        public ma_device* pDevice;
    }

    public enum ma_backend
    {
        ma_backend_wasapi,
        ma_backend_dsound,
        ma_backend_winmm,
        ma_backend_coreaudio,
        ma_backend_sndio,
        ma_backend_audio4,
        ma_backend_oss,
        ma_backend_pulseaudio,
        ma_backend_alsa,
        ma_backend_jack,
        ma_backend_aaudio,
        ma_backend_opensl,
        ma_backend_webaudio,
        ma_backend_custom,
        ma_backend_null,
    }

    public partial struct ma_device_job_thread_config
    {
        [NativeTypeName("ma_bool32")]
        public uint noThread;

        [NativeTypeName("ma_uint32")]
        public uint jobQueueCapacity;

        [NativeTypeName("ma_uint32")]
        public uint jobQueueFlags;
    }

    public unsafe partial struct ma_device_job_thread
    {
        [NativeTypeName("ma_thread")]
        public void* thread;

        public ma_job_queue jobQueue;

        [NativeTypeName("ma_bool32")]
        public uint _hasThread;
    }

    public enum ma_device_notification_type
    {
        ma_device_notification_type_started,
        ma_device_notification_type_stopped,
        ma_device_notification_type_rerouted,
        ma_device_notification_type_interruption_began,
        ma_device_notification_type_interruption_ended,
    }

    public unsafe partial struct ma_device_notification
    {
        public ma_device* pDevice;

        public ma_device_notification_type type;

        [NativeTypeName("union (anonymous union at miniaudio/vendor/miniaudio.h:6326:5)")]
        public _data_e__Union data;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _data_e__Union
        {
            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6328:9)")]
            public _started_e__Struct started;

            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6332:9)")]
            public _stopped_e__Struct stopped;

            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6336:9)")]
            public _rerouted_e__Struct rerouted;

            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6340:9)")]
            public _interruption_e__Struct interruption;

            public partial struct _started_e__Struct
            {
                public int _unused;
            }

            public partial struct _stopped_e__Struct
            {
                public int _unused;
            }

            public partial struct _rerouted_e__Struct
            {
                public int _unused;
            }

            public partial struct _interruption_e__Struct
            {
                public int _unused;
            }
        }
    }

    public enum ma_device_type
    {
        ma_device_type_playback = 1,
        ma_device_type_capture = 2,
        ma_device_type_duplex = ma_device_type_playback | ma_device_type_capture,
        ma_device_type_loopback = 4,
    }

    public enum ma_share_mode
    {
        ma_share_mode_shared = 0,
        ma_share_mode_exclusive,
    }

    public enum ma_ios_session_category
    {
        ma_ios_session_category_default = 0,
        ma_ios_session_category_none,
        ma_ios_session_category_ambient,
        ma_ios_session_category_solo_ambient,
        ma_ios_session_category_playback,
        ma_ios_session_category_record,
        ma_ios_session_category_play_and_record,
        ma_ios_session_category_multi_route,
    }

    public enum ma_ios_session_category_option
    {
        ma_ios_session_category_option_mix_with_others = 0x01,
        ma_ios_session_category_option_duck_others = 0x02,
        ma_ios_session_category_option_allow_bluetooth = 0x04,
        ma_ios_session_category_option_default_to_speaker = 0x08,
        ma_ios_session_category_option_interrupt_spoken_audio_and_mix_with_others = 0x11,
        ma_ios_session_category_option_allow_bluetooth_a2dp = 0x20,
        ma_ios_session_category_option_allow_air_play = 0x40,
    }

    public enum ma_opensl_stream_type
    {
        ma_opensl_stream_type_default = 0,
        ma_opensl_stream_type_voice,
        ma_opensl_stream_type_system,
        ma_opensl_stream_type_ring,
        ma_opensl_stream_type_media,
        ma_opensl_stream_type_alarm,
        ma_opensl_stream_type_notification,
    }

    public enum ma_opensl_recording_preset
    {
        ma_opensl_recording_preset_default = 0,
        ma_opensl_recording_preset_generic,
        ma_opensl_recording_preset_camcorder,
        ma_opensl_recording_preset_voice_recognition,
        ma_opensl_recording_preset_voice_communication,
        ma_opensl_recording_preset_voice_unprocessed,
    }

    public enum ma_wasapi_usage
    {
        ma_wasapi_usage_default = 0,
        ma_wasapi_usage_games,
        ma_wasapi_usage_pro_audio,
    }

    public enum ma_aaudio_usage
    {
        ma_aaudio_usage_default = 0,
        ma_aaudio_usage_media,
        ma_aaudio_usage_voice_communication,
        ma_aaudio_usage_voice_communication_signalling,
        ma_aaudio_usage_alarm,
        ma_aaudio_usage_notification,
        ma_aaudio_usage_notification_ringtone,
        ma_aaudio_usage_notification_event,
        ma_aaudio_usage_assistance_accessibility,
        ma_aaudio_usage_assistance_navigation_guidance,
        ma_aaudio_usage_assistance_sonification,
        ma_aaudio_usage_game,
        ma_aaudio_usage_assitant,
        ma_aaudio_usage_emergency,
        ma_aaudio_usage_safety,
        ma_aaudio_usage_vehicle_status,
        ma_aaudio_usage_announcement,
    }

    public enum ma_aaudio_content_type
    {
        ma_aaudio_content_type_default = 0,
        ma_aaudio_content_type_speech,
        ma_aaudio_content_type_music,
        ma_aaudio_content_type_movie,
        ma_aaudio_content_type_sonification,
    }

    public enum ma_aaudio_input_preset
    {
        ma_aaudio_input_preset_default = 0,
        ma_aaudio_input_preset_generic,
        ma_aaudio_input_preset_camcorder,
        ma_aaudio_input_preset_voice_recognition,
        ma_aaudio_input_preset_voice_communication,
        ma_aaudio_input_preset_unprocessed,
        ma_aaudio_input_preset_voice_performance,
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct ma_timer
    {
        [FieldOffset(0)]
        [NativeTypeName("ma_int64")]
        public long counter;

        [FieldOffset(0)]
        public double counterD;
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe partial struct ma_device_id
    {
        [FieldOffset(0)]
        [NativeTypeName("wchar_t [64]")]
        public fixed ushort wasapi[64];

        [FieldOffset(0)]
        [NativeTypeName("ma_uint8 [16]")]
        public fixed byte dsound[16];

        [FieldOffset(0)]
        [NativeTypeName("ma_uint32")]
        public uint winmm;

        [FieldOffset(0)]
        [NativeTypeName("char [256]")]
        public fixed sbyte alsa[256];

        [FieldOffset(0)]
        [NativeTypeName("char [256]")]
        public fixed sbyte pulse[256];

        [FieldOffset(0)]
        public int jack;

        [FieldOffset(0)]
        [NativeTypeName("char [256]")]
        public fixed sbyte coreaudio[256];

        [FieldOffset(0)]
        [NativeTypeName("char [256]")]
        public fixed sbyte sndio[256];

        [FieldOffset(0)]
        [NativeTypeName("char [256]")]
        public fixed sbyte audio4[256];

        [FieldOffset(0)]
        [NativeTypeName("char [64]")]
        public fixed sbyte oss[64];

        [FieldOffset(0)]
        [NativeTypeName("ma_int32")]
        public int aaudio;

        [FieldOffset(0)]
        [NativeTypeName("ma_uint32")]
        public uint opensl;

        [FieldOffset(0)]
        [NativeTypeName("char [32]")]
        public fixed sbyte webaudio[32];

        [FieldOffset(0)]
        [NativeTypeName("union (anonymous union at miniaudio/vendor/miniaudio.h:6592:5)")]
        public _custom_e__Union custom;

        [FieldOffset(0)]
        public int nullbackend;

        [StructLayout(LayoutKind.Explicit)]
        public unsafe partial struct _custom_e__Union
        {
            [FieldOffset(0)]
            public int i;

            [FieldOffset(0)]
            [NativeTypeName("char [256]")]
            public fixed sbyte s[256];

            [FieldOffset(0)]
            public void* p;
        }
    }

    public unsafe partial struct ma_device_info
    {
        public ma_device_id id;

        [NativeTypeName("char [256]")]
        public fixed sbyte name[256];

        [NativeTypeName("ma_bool32")]
        public uint isDefault;

        [NativeTypeName("ma_uint32")]
        public uint nativeDataFormatCount;

        [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6620:5) [64]")]
        public _nativeDataFormats_e__FixedBuffer nativeDataFormats;

        public partial struct _Anonymous_e__Struct
        {
            public ma_format format;

            [NativeTypeName("ma_uint32")]
            public uint channels;

            [NativeTypeName("ma_uint32")]
            public uint sampleRate;

            [NativeTypeName("ma_uint32")]
            public uint flags;
        }

        public partial struct _nativeDataFormats_e__FixedBuffer
        {
            public _Anonymous_e__Struct e0;
            public _Anonymous_e__Struct e1;
            public _Anonymous_e__Struct e2;
            public _Anonymous_e__Struct e3;
            public _Anonymous_e__Struct e4;
            public _Anonymous_e__Struct e5;
            public _Anonymous_e__Struct e6;
            public _Anonymous_e__Struct e7;
            public _Anonymous_e__Struct e8;
            public _Anonymous_e__Struct e9;
            public _Anonymous_e__Struct e10;
            public _Anonymous_e__Struct e11;
            public _Anonymous_e__Struct e12;
            public _Anonymous_e__Struct e13;
            public _Anonymous_e__Struct e14;
            public _Anonymous_e__Struct e15;
            public _Anonymous_e__Struct e16;
            public _Anonymous_e__Struct e17;
            public _Anonymous_e__Struct e18;
            public _Anonymous_e__Struct e19;
            public _Anonymous_e__Struct e20;
            public _Anonymous_e__Struct e21;
            public _Anonymous_e__Struct e22;
            public _Anonymous_e__Struct e23;
            public _Anonymous_e__Struct e24;
            public _Anonymous_e__Struct e25;
            public _Anonymous_e__Struct e26;
            public _Anonymous_e__Struct e27;
            public _Anonymous_e__Struct e28;
            public _Anonymous_e__Struct e29;
            public _Anonymous_e__Struct e30;
            public _Anonymous_e__Struct e31;
            public _Anonymous_e__Struct e32;
            public _Anonymous_e__Struct e33;
            public _Anonymous_e__Struct e34;
            public _Anonymous_e__Struct e35;
            public _Anonymous_e__Struct e36;
            public _Anonymous_e__Struct e37;
            public _Anonymous_e__Struct e38;
            public _Anonymous_e__Struct e39;
            public _Anonymous_e__Struct e40;
            public _Anonymous_e__Struct e41;
            public _Anonymous_e__Struct e42;
            public _Anonymous_e__Struct e43;
            public _Anonymous_e__Struct e44;
            public _Anonymous_e__Struct e45;
            public _Anonymous_e__Struct e46;
            public _Anonymous_e__Struct e47;
            public _Anonymous_e__Struct e48;
            public _Anonymous_e__Struct e49;
            public _Anonymous_e__Struct e50;
            public _Anonymous_e__Struct e51;
            public _Anonymous_e__Struct e52;
            public _Anonymous_e__Struct e53;
            public _Anonymous_e__Struct e54;
            public _Anonymous_e__Struct e55;
            public _Anonymous_e__Struct e56;
            public _Anonymous_e__Struct e57;
            public _Anonymous_e__Struct e58;
            public _Anonymous_e__Struct e59;
            public _Anonymous_e__Struct e60;
            public _Anonymous_e__Struct e61;
            public _Anonymous_e__Struct e62;
            public _Anonymous_e__Struct e63;

            public ref _Anonymous_e__Struct this[int index]
            {
                get
                {
                    return ref AsSpan()[index];
                }
            }

            public Span<_Anonymous_e__Struct> AsSpan() => MemoryMarshal.CreateSpan(ref e0, 64);
        }
    }

    public unsafe partial struct ma_device_config
    {
        public ma_device_type deviceType;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        [NativeTypeName("ma_uint32")]
        public uint periodSizeInFrames;

        [NativeTypeName("ma_uint32")]
        public uint periodSizeInMilliseconds;

        [NativeTypeName("ma_uint32")]
        public uint periods;

        public ma_performance_profile performanceProfile;

        [NativeTypeName("ma_bool8")]
        public byte noPreSilencedOutputBuffer;

        [NativeTypeName("ma_bool8")]
        public byte noClip;

        [NativeTypeName("ma_bool8")]
        public byte noDisableDenormals;

        [NativeTypeName("ma_bool8")]
        public byte noFixedSizedCallback;

        [NativeTypeName("ma_device_data_proc")]
        public delegate* unmanaged[Cdecl]<ma_device*, void*, void*, uint, void> dataCallback;

        [NativeTypeName("ma_device_notification_proc")]
        public delegate* unmanaged[Cdecl]<ma_device_notification*, void> notificationCallback;

        [NativeTypeName("ma_stop_proc")]
        public delegate* unmanaged[Cdecl]<ma_device*, void> stopCallback;

        public void* pUserData;

        public ma_resampler_config resampling;

        [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6646:5)")]
        public _playback_e__Struct playback;

        [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6656:5)")]
        public _capture_e__Struct capture;

        [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6667:5)")]
        public _wasapi_e__Struct wasapi;

        [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6677:5)")]
        public _alsa_e__Struct alsa;

        [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6684:5)")]
        public _pulse_e__Struct pulse;

        [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6689:5)")]
        public _coreaudio_e__Struct coreaudio;

        [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6693:5)")]
        public _opensl_e__Struct opensl;

        [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6698:5)")]
        public _aaudio_e__Struct aaudio;

        public unsafe partial struct _playback_e__Struct
        {
            [NativeTypeName("const ma_device_id *")]
            public ma_device_id* pDeviceID;

            public ma_format format;

            [NativeTypeName("ma_uint32")]
            public uint channels;

            [NativeTypeName("ma_channel *")]
            public byte* pChannelMap;

            public ma_channel_mix_mode channelMixMode;

            [NativeTypeName("ma_bool32")]
            public uint calculateLFEFromSpatialChannels;

            public ma_share_mode shareMode;
        }

        public unsafe partial struct _capture_e__Struct
        {
            [NativeTypeName("const ma_device_id *")]
            public ma_device_id* pDeviceID;

            public ma_format format;

            [NativeTypeName("ma_uint32")]
            public uint channels;

            [NativeTypeName("ma_channel *")]
            public byte* pChannelMap;

            public ma_channel_mix_mode channelMixMode;

            [NativeTypeName("ma_bool32")]
            public uint calculateLFEFromSpatialChannels;

            public ma_share_mode shareMode;
        }

        public partial struct _wasapi_e__Struct
        {
            public ma_wasapi_usage usage;

            [NativeTypeName("ma_bool8")]
            public byte noAutoConvertSRC;

            [NativeTypeName("ma_bool8")]
            public byte noDefaultQualitySRC;

            [NativeTypeName("ma_bool8")]
            public byte noAutoStreamRouting;

            [NativeTypeName("ma_bool8")]
            public byte noHardwareOffloading;

            [NativeTypeName("ma_uint32")]
            public uint loopbackProcessID;

            [NativeTypeName("ma_bool8")]
            public byte loopbackProcessExclude;
        }

        public partial struct _alsa_e__Struct
        {
            [NativeTypeName("ma_bool32")]
            public uint noMMap;

            [NativeTypeName("ma_bool32")]
            public uint noAutoFormat;

            [NativeTypeName("ma_bool32")]
            public uint noAutoChannels;

            [NativeTypeName("ma_bool32")]
            public uint noAutoResample;
        }

        public unsafe partial struct _pulse_e__Struct
        {
            [NativeTypeName("const char *")]
            public sbyte* pStreamNamePlayback;

            [NativeTypeName("const char *")]
            public sbyte* pStreamNameCapture;
        }

        public partial struct _coreaudio_e__Struct
        {
            [NativeTypeName("ma_bool32")]
            public uint allowNominalSampleRateChange;
        }

        public partial struct _opensl_e__Struct
        {
            public ma_opensl_stream_type streamType;

            public ma_opensl_recording_preset recordingPreset;
        }

        public partial struct _aaudio_e__Struct
        {
            public ma_aaudio_usage usage;

            public ma_aaudio_content_type contentType;

            public ma_aaudio_input_preset inputPreset;

            [NativeTypeName("ma_bool32")]
            public uint noAutoStartAfterReroute;
        }
    }

    public unsafe partial struct ma_device_descriptor
    {
        [NativeTypeName("const ma_device_id *")]
        public ma_device_id* pDeviceID;

        public ma_share_mode shareMode;

        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        [NativeTypeName("ma_channel [254]")]
        public fixed byte channelMap[254];

        [NativeTypeName("ma_uint32")]
        public uint periodSizeInFrames;

        [NativeTypeName("ma_uint32")]
        public uint periodSizeInMilliseconds;

        [NativeTypeName("ma_uint32")]
        public uint periodCount;
    }

    public unsafe partial struct ma_backend_callbacks
    {
        [NativeTypeName("ma_result (*)(ma_context *, const ma_context_config *, ma_backend_callbacks *)")]
        public delegate* unmanaged[Cdecl]<ma_context*, ma_context_config*, ma_backend_callbacks*, ma_result> onContextInit;

        [NativeTypeName("ma_result (*)(ma_context *)")]
        public delegate* unmanaged[Cdecl]<ma_context*, ma_result> onContextUninit;

        [NativeTypeName("ma_result (*)(ma_context *, ma_enum_devices_callback_proc, void *)")]
        public delegate* unmanaged[Cdecl]<ma_context*, delegate* unmanaged[Cdecl]<ma_context*, ma_device_type, ma_device_info*, void*, uint>, void*, ma_result> onContextEnumerateDevices;

        [NativeTypeName("ma_result (*)(ma_context *, ma_device_type, const ma_device_id *, ma_device_info *)")]
        public delegate* unmanaged[Cdecl]<ma_context*, ma_device_type, ma_device_id*, ma_device_info*, ma_result> onContextGetDeviceInfo;

        [NativeTypeName("ma_result (*)(ma_device *, const ma_device_config *, ma_device_descriptor *, ma_device_descriptor *)")]
        public delegate* unmanaged[Cdecl]<ma_device*, ma_device_config*, ma_device_descriptor*, ma_device_descriptor*, ma_result> onDeviceInit;

        [NativeTypeName("ma_result (*)(ma_device *)")]
        public delegate* unmanaged[Cdecl]<ma_device*, ma_result> onDeviceUninit;

        [NativeTypeName("ma_result (*)(ma_device *)")]
        public delegate* unmanaged[Cdecl]<ma_device*, ma_result> onDeviceStart;

        [NativeTypeName("ma_result (*)(ma_device *)")]
        public delegate* unmanaged[Cdecl]<ma_device*, ma_result> onDeviceStop;

        [NativeTypeName("ma_result (*)(ma_device *, void *, ma_uint32, ma_uint32 *)")]
        public delegate* unmanaged[Cdecl]<ma_device*, void*, uint, uint*, ma_result> onDeviceRead;

        [NativeTypeName("ma_result (*)(ma_device *, const void *, ma_uint32, ma_uint32 *)")]
        public delegate* unmanaged[Cdecl]<ma_device*, void*, uint, uint*, ma_result> onDeviceWrite;

        [NativeTypeName("ma_result (*)(ma_device *)")]
        public delegate* unmanaged[Cdecl]<ma_device*, ma_result> onDeviceDataLoop;

        [NativeTypeName("ma_result (*)(ma_device *)")]
        public delegate* unmanaged[Cdecl]<ma_device*, ma_result> onDeviceDataLoopWakeup;

        [NativeTypeName("ma_result (*)(ma_device *, ma_device_type, ma_device_info *)")]
        public delegate* unmanaged[Cdecl]<ma_device*, ma_device_type, ma_device_info*, ma_result> onDeviceGetInfo;
    }

    public unsafe partial struct ma_context_config
    {
        public ma_log* pLog;

        public ma_thread_priority threadPriority;

        [NativeTypeName("size_t")]
        public nuint threadStackSize;

        public void* pUserData;

        public ma_allocation_callbacks allocationCallbacks;

        [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6839:5)")]
        public _alsa_e__Struct alsa;

        [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6843:5)")]
        public _pulse_e__Struct pulse;

        [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6849:5)")]
        public _coreaudio_e__Struct coreaudio;

        [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6856:5)")]
        public _jack_e__Struct jack;

        public ma_backend_callbacks custom;

        public partial struct _alsa_e__Struct
        {
            [NativeTypeName("ma_bool32")]
            public uint useVerboseDeviceEnumeration;
        }

        public unsafe partial struct _pulse_e__Struct
        {
            [NativeTypeName("const char *")]
            public sbyte* pApplicationName;

            [NativeTypeName("const char *")]
            public sbyte* pServerName;

            [NativeTypeName("ma_bool32")]
            public uint tryAutoSpawn;
        }

        public partial struct _coreaudio_e__Struct
        {
            public ma_ios_session_category sessionCategory;

            [NativeTypeName("ma_uint32")]
            public uint sessionCategoryOptions;

            [NativeTypeName("ma_bool32")]
            public uint noAudioSessionActivate;

            [NativeTypeName("ma_bool32")]
            public uint noAudioSessionDeactivate;
        }

        public unsafe partial struct _jack_e__Struct
        {
            [NativeTypeName("const char *")]
            public sbyte* pClientName;

            [NativeTypeName("ma_bool32")]
            public uint tryStartServer;
        }
    }

    public unsafe partial struct ma_context_command__wasapi
    {
        public int code;

        [NativeTypeName("ma_event *")]
        public void** pEvent;

        [NativeTypeName("union (anonymous union at miniaudio/vendor/miniaudio.h:6869:5)")]
        public _data_e__Union data;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _data_e__Union
        {
            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6871:9)")]
            public _quit_e__Struct quit;

            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6875:9)")]
            public _createAudioClient_e__Struct createAudioClient;

            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6882:9)")]
            public _releaseAudioClient_e__Struct releaseAudioClient;

            public partial struct _quit_e__Struct
            {
                public int _unused;
            }

            public unsafe partial struct _createAudioClient_e__Struct
            {
                public ma_device_type deviceType;

                public void* pAudioClient;

                public void** ppAudioClientService;

                public ma_result* pResult;
            }

            public unsafe partial struct _releaseAudioClient_e__Struct
            {
                public ma_device* pDevice;

                public ma_device_type deviceType;
            }
        }
    }

    public unsafe partial struct ma_context
    {
        public ma_backend_callbacks callbacks;

        public ma_backend backend;

        public ma_log* pLog;

        public ma_log log;

        public ma_thread_priority threadPriority;

        [NativeTypeName("size_t")]
        public nuint threadStackSize;

        public void* pUserData;

        public ma_allocation_callbacks allocationCallbacks;

        [NativeTypeName("ma_mutex")]
        public void* deviceEnumLock;

        [NativeTypeName("ma_mutex")]
        public void* deviceInfoLock;

        [NativeTypeName("ma_uint32")]
        public uint deviceInfoCapacity;

        [NativeTypeName("ma_uint32")]
        public uint playbackDeviceInfoCount;

        [NativeTypeName("ma_uint32")]
        public uint captureDeviceInfoCount;

        public ma_device_info* pDeviceInfos;

        [NativeTypeName("ma_context::(anonymous union at miniaudio/vendor/miniaudio.h:6907:5)")]
        public _Anonymous1_e__Union Anonymous1;

        [NativeTypeName("ma_context::(anonymous union at miniaudio/vendor/miniaudio.h:7260:5)")]
        public _Anonymous2_e__Union Anonymous2;

        public ref _Anonymous1_e__Union._wasapi_e__Struct wasapi
        {
            get
            {
                return ref MemoryMarshal.GetReference(MemoryMarshal.CreateSpan(ref Anonymous1.wasapi, 1));
            }
        }

        public ref _Anonymous1_e__Union._dsound_e__Struct dsound
        {
            get
            {
                return ref MemoryMarshal.GetReference(MemoryMarshal.CreateSpan(ref Anonymous1.dsound, 1));
            }
        }

        public ref _Anonymous1_e__Union._winmm_e__Struct winmm
        {
            get
            {
                return ref MemoryMarshal.GetReference(MemoryMarshal.CreateSpan(ref Anonymous1.winmm, 1));
            }
        }

        public ref _Anonymous1_e__Union._jack_e__Struct jack
        {
            get
            {
                return ref MemoryMarshal.GetReference(MemoryMarshal.CreateSpan(ref Anonymous1.jack, 1));
            }
        }

        public ref _Anonymous1_e__Union._null_backend_e__Struct null_backend
        {
            get
            {
                return ref MemoryMarshal.GetReference(MemoryMarshal.CreateSpan(ref Anonymous1.null_backend, 1));
            }
        }

        public ref _Anonymous2_e__Union._win32_e__Struct win32
        {
            get
            {
                return ref MemoryMarshal.GetReference(MemoryMarshal.CreateSpan(ref Anonymous2.win32, 1));
            }
        }

        public ref int _unused
        {
            get
            {
                return ref MemoryMarshal.GetReference(MemoryMarshal.CreateSpan(ref Anonymous2._unused, 1));
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _Anonymous1_e__Union
        {
            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6910:9)")]
            public _wasapi_e__Struct wasapi;

            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6926:9)")]
            public _dsound_e__Struct dsound;

            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:6936:9)")]
            public _winmm_e__Struct winmm;

            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:7106:9)")]
            public _jack_e__Struct jack;

            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:7253:9)")]
            public _null_backend_e__Struct null_backend;

            public unsafe partial struct _wasapi_e__Struct
            {
                [NativeTypeName("ma_thread")]
                public void* commandThread;

                [NativeTypeName("ma_mutex")]
                public void* commandLock;

                [NativeTypeName("ma_semaphore")]
                public void* commandSem;

                [NativeTypeName("ma_uint32")]
                public uint commandIndex;

                [NativeTypeName("ma_uint32")]
                public uint commandCount;

                [NativeTypeName("ma_context_command__wasapi [4]")]
                public _commands_e__FixedBuffer commands;

                [NativeTypeName("ma_handle")]
                public void* hAvrt;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> AvSetMmThreadCharacteristicsW;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> AvRevertMmThreadcharacteristics;

                [NativeTypeName("ma_handle")]
                public void* hMMDevapi;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> ActivateAudioInterfaceAsync;

                public partial struct _commands_e__FixedBuffer
                {
                    public ma_context_command__wasapi e0;
                    public ma_context_command__wasapi e1;
                    public ma_context_command__wasapi e2;
                    public ma_context_command__wasapi e3;

                    public ref ma_context_command__wasapi this[int index]
                    {
                        get
                        {
                            return ref AsSpan()[index];
                        }
                    }

                    public Span<ma_context_command__wasapi> AsSpan() => MemoryMarshal.CreateSpan(ref e0, 4);
                }
            }

            public unsafe partial struct _dsound_e__Struct
            {
                [NativeTypeName("ma_handle")]
                public void* hDSoundDLL;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> DirectSoundCreate;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> DirectSoundEnumerateA;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> DirectSoundCaptureCreate;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> DirectSoundCaptureEnumerateA;
            }

            public unsafe partial struct _winmm_e__Struct
            {
                [NativeTypeName("ma_handle")]
                public void* hWinMM;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> waveOutGetNumDevs;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> waveOutGetDevCapsA;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> waveOutOpen;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> waveOutClose;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> waveOutPrepareHeader;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> waveOutUnprepareHeader;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> waveOutWrite;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> waveOutReset;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> waveInGetNumDevs;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> waveInGetDevCapsA;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> waveInOpen;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> waveInClose;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> waveInPrepareHeader;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> waveInUnprepareHeader;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> waveInAddBuffer;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> waveInStart;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> waveInReset;
            }

            public unsafe partial struct _jack_e__Struct
            {
                [NativeTypeName("ma_handle")]
                public void* jackSO;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> jack_client_open;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> jack_client_close;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> jack_client_name_size;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> jack_set_process_callback;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> jack_set_buffer_size_callback;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> jack_on_shutdown;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> jack_get_sample_rate;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> jack_get_buffer_size;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> jack_get_ports;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> jack_activate;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> jack_deactivate;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> jack_connect;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> jack_port_register;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> jack_port_name;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> jack_port_get_buffer;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> jack_free;

                [NativeTypeName("char *")]
                public sbyte* pClientName;

                [NativeTypeName("ma_bool32")]
                public uint tryStartServer;
            }

            public partial struct _null_backend_e__Struct
            {
                public int _unused;
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _Anonymous2_e__Union
        {
            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:7263:9)")]
            public _win32_e__Struct win32;

            [FieldOffset(0)]
            public int _unused;

            public unsafe partial struct _win32_e__Struct
            {
                [NativeTypeName("ma_handle")]
                public void* hOle32DLL;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> CoInitializeEx;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> CoUninitialize;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> CoCreateInstance;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> CoTaskMemFree;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> PropVariantClear;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> StringFromGUID2;

                [NativeTypeName("ma_handle")]
                public void* hUser32DLL;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> GetForegroundWindow;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> GetDesktopWindow;

                [NativeTypeName("ma_handle")]
                public void* hAdvapi32DLL;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> RegOpenKeyExA;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> RegCloseKey;

                [NativeTypeName("ma_proc")]
                public delegate* unmanaged[Cdecl]<void> RegQueryValueExA;
            }
        }
    }

    public unsafe partial struct ma_device
    {
        public ma_context* pContext;

        public ma_device_type type;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        public ma_device_state state;

        [NativeTypeName("ma_device_data_proc")]
        public delegate* unmanaged[Cdecl]<ma_device*, void*, void*, uint, void> onData;

        [NativeTypeName("ma_device_notification_proc")]
        public delegate* unmanaged[Cdecl]<ma_device_notification*, void> onNotification;

        [NativeTypeName("ma_stop_proc")]
        public delegate* unmanaged[Cdecl]<ma_device*, void> onStop;

        public void* pUserData;

        [NativeTypeName("ma_mutex")]
        public void* startStopLock;

        [NativeTypeName("ma_event")]
        public void* wakeupEvent;

        [NativeTypeName("ma_event")]
        public void* startEvent;

        [NativeTypeName("ma_event")]
        public void* stopEvent;

        [NativeTypeName("ma_thread")]
        public void* thread;

        public ma_result workResult;

        [NativeTypeName("ma_bool8")]
        public byte isOwnerOfContext;

        [NativeTypeName("ma_bool8")]
        public byte noPreSilencedOutputBuffer;

        [NativeTypeName("ma_bool8")]
        public byte noClip;

        [NativeTypeName("ma_bool8")]
        public byte noDisableDenormals;

        [NativeTypeName("ma_bool8")]
        public byte noFixedSizedCallback;

        public float masterVolumeFactor;

        public ma_duplex_rb duplexRB;

        [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:7331:5)")]
        public _resampling_e__Struct resampling;

        [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:7341:5)")]
        public _playback_e__Struct playback;

        [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:7367:5)")]
        public _capture_e__Struct capture;

        [NativeTypeName("ma_device::(anonymous union at miniaudio/vendor/miniaudio.h:7390:5)")]
        public _Anonymous_e__Union Anonymous;

        public ref _Anonymous_e__Union._wasapi_e__Struct wasapi
        {
            get
            {
                return ref MemoryMarshal.GetReference(MemoryMarshal.CreateSpan(ref Anonymous.wasapi, 1));
            }
        }

        public ref _Anonymous_e__Union._dsound_e__Struct dsound
        {
            get
            {
                return ref MemoryMarshal.GetReference(MemoryMarshal.CreateSpan(ref Anonymous.dsound, 1));
            }
        }

        public ref _Anonymous_e__Union._winmm_e__Struct winmm
        {
            get
            {
                return ref MemoryMarshal.GetReference(MemoryMarshal.CreateSpan(ref Anonymous.winmm, 1));
            }
        }

        public ref _Anonymous_e__Union._jack_e__Struct jack
        {
            get
            {
                return ref MemoryMarshal.GetReference(MemoryMarshal.CreateSpan(ref Anonymous.jack, 1));
            }
        }

        public ref _Anonymous_e__Union._null_device_e__Struct null_device
        {
            get
            {
                return ref MemoryMarshal.GetReference(MemoryMarshal.CreateSpan(ref Anonymous.null_device, 1));
            }
        }

        public unsafe partial struct _resampling_e__Struct
        {
            public ma_resample_algorithm algorithm;

            public ma_resampling_backend_vtable* pBackendVTable;

            public void* pBackendUserData;

            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:7336:9)")]
            public _linear_e__Struct linear;

            public partial struct _linear_e__Struct
            {
                [NativeTypeName("ma_uint32")]
                public uint lpfOrder;
            }
        }

        public unsafe partial struct _playback_e__Struct
        {
            public ma_device_id* pID;

            public ma_device_id id;

            [NativeTypeName("char [256]")]
            public fixed sbyte name[256];

            public ma_share_mode shareMode;

            public ma_format format;

            [NativeTypeName("ma_uint32")]
            public uint channels;

            [NativeTypeName("ma_channel [254]")]
            public fixed byte channelMap[254];

            public ma_format internalFormat;

            [NativeTypeName("ma_uint32")]
            public uint internalChannels;

            [NativeTypeName("ma_uint32")]
            public uint internalSampleRate;

            [NativeTypeName("ma_channel [254]")]
            public fixed byte internalChannelMap[254];

            [NativeTypeName("ma_uint32")]
            public uint internalPeriodSizeInFrames;

            [NativeTypeName("ma_uint32")]
            public uint internalPeriods;

            public ma_channel_mix_mode channelMixMode;

            [NativeTypeName("ma_bool32")]
            public uint calculateLFEFromSpatialChannels;

            public ma_data_converter converter;

            public void* pIntermediaryBuffer;

            [NativeTypeName("ma_uint32")]
            public uint intermediaryBufferCap;

            [NativeTypeName("ma_uint32")]
            public uint intermediaryBufferLen;

            public void* pInputCache;

            [NativeTypeName("ma_uint64")]
            public ulong inputCacheCap;

            [NativeTypeName("ma_uint64")]
            public ulong inputCacheConsumed;

            [NativeTypeName("ma_uint64")]
            public ulong inputCacheRemaining;
        }

        public unsafe partial struct _capture_e__Struct
        {
            public ma_device_id* pID;

            public ma_device_id id;

            [NativeTypeName("char [256]")]
            public fixed sbyte name[256];

            public ma_share_mode shareMode;

            public ma_format format;

            [NativeTypeName("ma_uint32")]
            public uint channels;

            [NativeTypeName("ma_channel [254]")]
            public fixed byte channelMap[254];

            public ma_format internalFormat;

            [NativeTypeName("ma_uint32")]
            public uint internalChannels;

            [NativeTypeName("ma_uint32")]
            public uint internalSampleRate;

            [NativeTypeName("ma_channel [254]")]
            public fixed byte internalChannelMap[254];

            [NativeTypeName("ma_uint32")]
            public uint internalPeriodSizeInFrames;

            [NativeTypeName("ma_uint32")]
            public uint internalPeriods;

            public ma_channel_mix_mode channelMixMode;

            [NativeTypeName("ma_bool32")]
            public uint calculateLFEFromSpatialChannels;

            public ma_data_converter converter;

            public void* pIntermediaryBuffer;

            [NativeTypeName("ma_uint32")]
            public uint intermediaryBufferCap;

            [NativeTypeName("ma_uint32")]
            public uint intermediaryBufferLen;
        }

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _Anonymous_e__Union
        {
            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:7393:9)")]
            public _wasapi_e__Struct wasapi;

            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:7433:9)")]
            public _dsound_e__Struct dsound;

            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:7443:9)")]
            public _winmm_e__Struct winmm;

            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:7486:9)")]
            public _jack_e__Struct jack;

            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:7577:9)")]
            public _null_device_e__Struct null_device;

            public unsafe partial struct _wasapi_e__Struct
            {
                [NativeTypeName("ma_ptr")]
                public void* pAudioClientPlayback;

                [NativeTypeName("ma_ptr")]
                public void* pAudioClientCapture;

                [NativeTypeName("ma_ptr")]
                public void* pRenderClient;

                [NativeTypeName("ma_ptr")]
                public void* pCaptureClient;

                [NativeTypeName("ma_ptr")]
                public void* pDeviceEnumerator;

                public ma_IMMNotificationClient notificationClient;

                [NativeTypeName("ma_handle")]
                public void* hEventPlayback;

                [NativeTypeName("ma_handle")]
                public void* hEventCapture;

                [NativeTypeName("ma_uint32")]
                public uint actualBufferSizeInFramesPlayback;

                [NativeTypeName("ma_uint32")]
                public uint actualBufferSizeInFramesCapture;

                [NativeTypeName("ma_uint32")]
                public uint originalPeriodSizeInFrames;

                [NativeTypeName("ma_uint32")]
                public uint originalPeriodSizeInMilliseconds;

                [NativeTypeName("ma_uint32")]
                public uint originalPeriods;

                public ma_performance_profile originalPerformanceProfile;

                [NativeTypeName("ma_uint32")]
                public uint periodSizeInFramesPlayback;

                [NativeTypeName("ma_uint32")]
                public uint periodSizeInFramesCapture;

                public void* pMappedBufferCapture;

                [NativeTypeName("ma_uint32")]
                public uint mappedBufferCaptureCap;

                [NativeTypeName("ma_uint32")]
                public uint mappedBufferCaptureLen;

                public void* pMappedBufferPlayback;

                [NativeTypeName("ma_uint32")]
                public uint mappedBufferPlaybackCap;

                [NativeTypeName("ma_uint32")]
                public uint mappedBufferPlaybackLen;

                [NativeTypeName("ma_bool32")]
                public uint isStartedCapture;

                [NativeTypeName("ma_bool32")]
                public uint isStartedPlayback;

                [NativeTypeName("ma_uint32")]
                public uint loopbackProcessID;

                [NativeTypeName("ma_bool8")]
                public byte loopbackProcessExclude;

                [NativeTypeName("ma_bool8")]
                public byte noAutoConvertSRC;

                [NativeTypeName("ma_bool8")]
                public byte noDefaultQualitySRC;

                [NativeTypeName("ma_bool8")]
                public byte noHardwareOffloading;

                [NativeTypeName("ma_bool8")]
                public byte allowCaptureAutoStreamRouting;

                [NativeTypeName("ma_bool8")]
                public byte allowPlaybackAutoStreamRouting;

                [NativeTypeName("ma_bool8")]
                public byte isDetachedPlayback;

                [NativeTypeName("ma_bool8")]
                public byte isDetachedCapture;

                public ma_wasapi_usage usage;

                public void* hAvrtHandle;
            }

            public unsafe partial struct _dsound_e__Struct
            {
                [NativeTypeName("ma_ptr")]
                public void* pPlayback;

                [NativeTypeName("ma_ptr")]
                public void* pPlaybackPrimaryBuffer;

                [NativeTypeName("ma_ptr")]
                public void* pPlaybackBuffer;

                [NativeTypeName("ma_ptr")]
                public void* pCapture;

                [NativeTypeName("ma_ptr")]
                public void* pCaptureBuffer;
            }

            public unsafe partial struct _winmm_e__Struct
            {
                [NativeTypeName("ma_handle")]
                public void* hDevicePlayback;

                [NativeTypeName("ma_handle")]
                public void* hDeviceCapture;

                [NativeTypeName("ma_handle")]
                public void* hEventPlayback;

                [NativeTypeName("ma_handle")]
                public void* hEventCapture;

                [NativeTypeName("ma_uint32")]
                public uint fragmentSizeInFrames;

                [NativeTypeName("ma_uint32")]
                public uint iNextHeaderPlayback;

                [NativeTypeName("ma_uint32")]
                public uint iNextHeaderCapture;

                [NativeTypeName("ma_uint32")]
                public uint headerFramesConsumedPlayback;

                [NativeTypeName("ma_uint32")]
                public uint headerFramesConsumedCapture;

                [NativeTypeName("ma_uint8 *")]
                public byte* pWAVEHDRPlayback;

                [NativeTypeName("ma_uint8 *")]
                public byte* pWAVEHDRCapture;

                [NativeTypeName("ma_uint8 *")]
                public byte* pIntermediaryBufferPlayback;

                [NativeTypeName("ma_uint8 *")]
                public byte* pIntermediaryBufferCapture;

                [NativeTypeName("ma_uint8 *")]
                public byte* _pHeapData;
            }

            public unsafe partial struct _jack_e__Struct
            {
                [NativeTypeName("ma_ptr")]
                public void* pClient;

                [NativeTypeName("ma_ptr *")]
                public void** ppPortsPlayback;

                [NativeTypeName("ma_ptr *")]
                public void** ppPortsCapture;

                public float* pIntermediaryBufferPlayback;

                public float* pIntermediaryBufferCapture;
            }

            public unsafe partial struct _null_device_e__Struct
            {
                [NativeTypeName("ma_thread")]
                public void* deviceThread;

                [NativeTypeName("ma_event")]
                public void* operationEvent;

                [NativeTypeName("ma_event")]
                public void* operationCompletionEvent;

                [NativeTypeName("ma_semaphore")]
                public void* operationSemaphore;

                [NativeTypeName("ma_uint32")]
                public uint operation;

                public ma_result operationResult;

                public ma_timer timer;

                public double priorRunTime;

                [NativeTypeName("ma_uint32")]
                public uint currentPeriodFramesRemainingPlayback;

                [NativeTypeName("ma_uint32")]
                public uint currentPeriodFramesRemainingCapture;

                [NativeTypeName("ma_uint64")]
                public ulong lastProcessedFramePlayback;

                [NativeTypeName("ma_uint64")]
                public ulong lastProcessedFrameCapture;

                [NativeTypeName("ma_bool32")]
                public uint isStarted;
            }
        }
    }

    public unsafe partial struct ma_data_source_vtable
    {
        [NativeTypeName("ma_result (*)(ma_data_source *, void *, ma_uint64, ma_uint64 *)")]
        public delegate* unmanaged[Cdecl]<void*, void*, ulong, ulong*, ma_result> onRead;

        [NativeTypeName("ma_result (*)(ma_data_source *, ma_uint64)")]
        public delegate* unmanaged[Cdecl]<void*, ulong, ma_result> onSeek;

        [NativeTypeName("ma_result (*)(ma_data_source *, ma_format *, ma_uint32 *, ma_uint32 *, ma_channel *, size_t)")]
        public delegate* unmanaged[Cdecl]<void*, ma_format*, uint*, uint*, byte*, nuint, ma_result> onGetDataFormat;

        [NativeTypeName("ma_result (*)(ma_data_source *, ma_uint64 *)")]
        public delegate* unmanaged[Cdecl]<void*, ulong*, ma_result> onGetCursor;

        [NativeTypeName("ma_result (*)(ma_data_source *, ma_uint64 *)")]
        public delegate* unmanaged[Cdecl]<void*, ulong*, ma_result> onGetLength;

        [NativeTypeName("ma_result (*)(ma_data_source *, ma_bool32)")]
        public delegate* unmanaged[Cdecl]<void*, uint, ma_result> onSetLooping;

        [NativeTypeName("ma_uint32")]
        public uint flags;
    }

    public unsafe partial struct ma_data_source_config
    {
        [NativeTypeName("const ma_data_source_vtable *")]
        public ma_data_source_vtable* vtable;
    }

    public unsafe partial struct ma_data_source_base
    {
        [NativeTypeName("const ma_data_source_vtable *")]
        public ma_data_source_vtable* vtable;

        [NativeTypeName("ma_uint64")]
        public ulong rangeBegInFrames;

        [NativeTypeName("ma_uint64")]
        public ulong rangeEndInFrames;

        [NativeTypeName("ma_uint64")]
        public ulong loopBegInFrames;

        [NativeTypeName("ma_uint64")]
        public ulong loopEndInFrames;

        [NativeTypeName("ma_data_source *")]
        public void* pCurrent;

        [NativeTypeName("ma_data_source *")]
        public void* pNext;

        [NativeTypeName("ma_data_source_get_next_proc")]
        public delegate* unmanaged[Cdecl]<void*, void*> onGetNext;

        [NativeTypeName("ma_bool32")]
        public uint isLooping;
    }

    public unsafe partial struct ma_audio_buffer_ref
    {
        public ma_data_source_base ds;

        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        [NativeTypeName("ma_uint64")]
        public ulong cursor;

        [NativeTypeName("ma_uint64")]
        public ulong sizeInFrames;

        [NativeTypeName("const void *")]
        public void* pData;
    }

    public unsafe partial struct ma_audio_buffer_config
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        [NativeTypeName("ma_uint64")]
        public ulong sizeInFrames;

        [NativeTypeName("const void *")]
        public void* pData;

        public ma_allocation_callbacks allocationCallbacks;
    }

    public unsafe partial struct ma_audio_buffer
    {
        public ma_audio_buffer_ref @ref;

        public ma_allocation_callbacks allocationCallbacks;

        [NativeTypeName("ma_bool32")]
        public uint ownsData;

        [NativeTypeName("ma_uint8 [1]")]
        public fixed byte _pExtraData[1];
    }

    public unsafe partial struct ma_paged_audio_buffer_page
    {
        public ma_paged_audio_buffer_page* pNext;

        [NativeTypeName("ma_uint64")]
        public ulong sizeInFrames;

        [NativeTypeName("ma_uint8 [1]")]
        public fixed byte pAudioData[1];
    }

    public unsafe partial struct ma_paged_audio_buffer_data
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        public ma_paged_audio_buffer_page head;

        public ma_paged_audio_buffer_page* pTail;
    }

    public unsafe partial struct ma_paged_audio_buffer_config
    {
        public ma_paged_audio_buffer_data* pData;
    }

    public unsafe partial struct ma_paged_audio_buffer
    {
        public ma_data_source_base ds;

        public ma_paged_audio_buffer_data* pData;

        public ma_paged_audio_buffer_page* pCurrent;

        [NativeTypeName("ma_uint64")]
        public ulong relativeCursor;

        [NativeTypeName("ma_uint64")]
        public ulong absoluteCursor;
    }

    public enum ma_open_mode_flags
    {
        MA_OPEN_MODE_READ = 0x00000001,
        MA_OPEN_MODE_WRITE = 0x00000002,
    }

    public enum ma_seek_origin
    {
        ma_seek_origin_start,
        ma_seek_origin_current,
        ma_seek_origin_end,
    }

    public partial struct ma_file_info
    {
        [NativeTypeName("ma_uint64")]
        public ulong sizeInBytes;
    }

    public unsafe partial struct ma_vfs_callbacks
    {
        [NativeTypeName("ma_result (*)(ma_vfs *, const char *, ma_uint32, ma_vfs_file *)")]
        public delegate* unmanaged[Cdecl]<void*, sbyte*, uint, void**, ma_result> onOpen;

        [NativeTypeName("ma_result (*)(ma_vfs *, const wchar_t *, ma_uint32, ma_vfs_file *)")]
        public delegate* unmanaged[Cdecl]<void*, ushort*, uint, void**, ma_result> onOpenW;

        [NativeTypeName("ma_result (*)(ma_vfs *, ma_vfs_file)")]
        public delegate* unmanaged[Cdecl]<void*, void*, ma_result> onClose;

        [NativeTypeName("ma_result (*)(ma_vfs *, ma_vfs_file, void *, size_t, size_t *)")]
        public delegate* unmanaged[Cdecl]<void*, void*, void*, nuint, nuint*, ma_result> onRead;

        [NativeTypeName("ma_result (*)(ma_vfs *, ma_vfs_file, const void *, size_t, size_t *)")]
        public delegate* unmanaged[Cdecl]<void*, void*, void*, nuint, nuint*, ma_result> onWrite;

        [NativeTypeName("ma_result (*)(ma_vfs *, ma_vfs_file, ma_int64, ma_seek_origin)")]
        public delegate* unmanaged[Cdecl]<void*, void*, long, ma_seek_origin, ma_result> onSeek;

        [NativeTypeName("ma_result (*)(ma_vfs *, ma_vfs_file, ma_int64 *)")]
        public delegate* unmanaged[Cdecl]<void*, void*, long*, ma_result> onTell;

        [NativeTypeName("ma_result (*)(ma_vfs *, ma_vfs_file, ma_file_info *)")]
        public delegate* unmanaged[Cdecl]<void*, void*, ma_file_info*, ma_result> onInfo;
    }

    public partial struct ma_default_vfs
    {
        public ma_vfs_callbacks cb;

        public ma_allocation_callbacks allocationCallbacks;
    }

    public enum ma_encoding_format
    {
        ma_encoding_format_unknown = 0,
        ma_encoding_format_wav,
        ma_encoding_format_flac,
        ma_encoding_format_mp3,
        ma_encoding_format_vorbis,
    }

    public partial struct ma_decoding_backend_config
    {
        public ma_format preferredFormat;

        [NativeTypeName("ma_uint32")]
        public uint seekPointCount;
    }

    public unsafe partial struct ma_decoding_backend_vtable
    {
        [NativeTypeName("ma_result (*)(void *, ma_read_proc, ma_seek_proc, ma_tell_proc, void *, const ma_decoding_backend_config *, const ma_allocation_callbacks *, ma_data_source **)")]
        public delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<void*, void*, nuint, nuint*, ma_result>, delegate* unmanaged[Cdecl]<void*, long, ma_seek_origin, ma_result>, delegate* unmanaged[Cdecl]<void*, long*, ma_result>, void*, ma_decoding_backend_config*, ma_allocation_callbacks*, void**, ma_result> onInit;

        [NativeTypeName("ma_result (*)(void *, const char *, const ma_decoding_backend_config *, const ma_allocation_callbacks *, ma_data_source **)")]
        public delegate* unmanaged[Cdecl]<void*, sbyte*, ma_decoding_backend_config*, ma_allocation_callbacks*, void**, ma_result> onInitFile;

        [NativeTypeName("ma_result (*)(void *, const wchar_t *, const ma_decoding_backend_config *, const ma_allocation_callbacks *, ma_data_source **)")]
        public delegate* unmanaged[Cdecl]<void*, ushort*, ma_decoding_backend_config*, ma_allocation_callbacks*, void**, ma_result> onInitFileW;

        [NativeTypeName("ma_result (*)(void *, const void *, size_t, const ma_decoding_backend_config *, const ma_allocation_callbacks *, ma_data_source **)")]
        public delegate* unmanaged[Cdecl]<void*, void*, nuint, ma_decoding_backend_config*, ma_allocation_callbacks*, void**, ma_result> onInitMemory;

        [NativeTypeName("void (*)(void *, ma_data_source *, const ma_allocation_callbacks *)")]
        public delegate* unmanaged[Cdecl]<void*, void*, ma_allocation_callbacks*, void> onUninit;
    }

    public unsafe partial struct ma_decoder_config
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        [NativeTypeName("ma_channel *")]
        public byte* pChannelMap;

        public ma_channel_mix_mode channelMixMode;

        public ma_dither_mode ditherMode;

        public ma_resampler_config resampling;

        public ma_allocation_callbacks allocationCallbacks;

        public ma_encoding_format encodingFormat;

        [NativeTypeName("ma_uint32")]
        public uint seekPointCount;

        public ma_decoding_backend_vtable** ppCustomBackendVTables;

        [NativeTypeName("ma_uint32")]
        public uint customBackendCount;

        public void* pCustomBackendUserData;
    }

    public unsafe partial struct ma_decoder
    {
        public ma_data_source_base ds;

        [NativeTypeName("ma_data_source *")]
        public void* pBackend;

        [NativeTypeName("const ma_decoding_backend_vtable *")]
        public ma_decoding_backend_vtable* pBackendVTable;

        public void* pBackendUserData;

        [NativeTypeName("ma_decoder_read_proc")]
        public delegate* unmanaged[Cdecl]<ma_decoder*, void*, nuint, nuint*, ma_result> onRead;

        [NativeTypeName("ma_decoder_seek_proc")]
        public delegate* unmanaged[Cdecl]<ma_decoder*, long, ma_seek_origin, ma_result> onSeek;

        [NativeTypeName("ma_decoder_tell_proc")]
        public delegate* unmanaged[Cdecl]<ma_decoder*, long*, ma_result> onTell;

        public void* pUserData;

        [NativeTypeName("ma_uint64")]
        public ulong readPointerInPCMFrames;

        public ma_format outputFormat;

        [NativeTypeName("ma_uint32")]
        public uint outputChannels;

        [NativeTypeName("ma_uint32")]
        public uint outputSampleRate;

        public ma_data_converter converter;

        public void* pInputCache;

        [NativeTypeName("ma_uint64")]
        public ulong inputCacheCap;

        [NativeTypeName("ma_uint64")]
        public ulong inputCacheConsumed;

        [NativeTypeName("ma_uint64")]
        public ulong inputCacheRemaining;

        public ma_allocation_callbacks allocationCallbacks;

        [NativeTypeName("union (anonymous union at miniaudio/vendor/miniaudio.h:9709:5)")]
        public _data_e__Union data;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _data_e__Union
        {
            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:9711:9)")]
            public _vfs_e__Struct vfs;

            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:9716:9)")]
            public _memory_e__Struct memory;

            public unsafe partial struct _vfs_e__Struct
            {
                [NativeTypeName("ma_vfs *")]
                public void* pVFS;

                [NativeTypeName("ma_vfs_file")]
                public void* file;
            }

            public unsafe partial struct _memory_e__Struct
            {
                [NativeTypeName("const ma_uint8 *")]
                public byte* pData;

                [NativeTypeName("size_t")]
                public nuint dataSize;

                [NativeTypeName("size_t")]
                public nuint currentReadPos;
            }
        }
    }

    public partial struct ma_encoder_config
    {
        public ma_encoding_format encodingFormat;

        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        public ma_allocation_callbacks allocationCallbacks;
    }

    public unsafe partial struct ma_encoder
    {
        public ma_encoder_config config;

        [NativeTypeName("ma_encoder_write_proc")]
        public delegate* unmanaged[Cdecl]<ma_encoder*, void*, nuint, nuint*, ma_result> onWrite;

        [NativeTypeName("ma_encoder_seek_proc")]
        public delegate* unmanaged[Cdecl]<ma_encoder*, long, ma_seek_origin, ma_result> onSeek;

        [NativeTypeName("ma_encoder_init_proc")]
        public delegate* unmanaged[Cdecl]<ma_encoder*, ma_result> onInit;

        [NativeTypeName("ma_encoder_uninit_proc")]
        public delegate* unmanaged[Cdecl]<ma_encoder*, void> onUninit;

        [NativeTypeName("ma_encoder_write_pcm_frames_proc")]
        public delegate* unmanaged[Cdecl]<ma_encoder*, void*, ulong, ulong*, ma_result> onWritePCMFrames;

        public void* pUserData;

        public void* pInternalEncoder;

        [NativeTypeName("union (anonymous union at miniaudio/vendor/miniaudio.h:9840:5)")]
        public _data_e__Union data;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _data_e__Union
        {
            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:9842:9)")]
            public _vfs_e__Struct vfs;

            public unsafe partial struct _vfs_e__Struct
            {
                [NativeTypeName("ma_vfs *")]
                public void* pVFS;

                [NativeTypeName("ma_vfs_file")]
                public void* file;
            }
        }
    }

    public enum ma_waveform_type
    {
        ma_waveform_type_sine,
        ma_waveform_type_square,
        ma_waveform_type_triangle,
        ma_waveform_type_sawtooth,
    }

    public partial struct ma_waveform_config
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        public ma_waveform_type type;

        public double amplitude;

        public double frequency;
    }

    public partial struct ma_waveform
    {
        public ma_data_source_base ds;

        public ma_waveform_config config;

        public double advance;

        public double time;
    }

    public enum ma_noise_type
    {
        ma_noise_type_white,
        ma_noise_type_pink,
        ma_noise_type_brownian,
    }

    public partial struct ma_noise_config
    {
        public ma_format format;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        public ma_noise_type type;

        [NativeTypeName("ma_int32")]
        public int seed;

        public double amplitude;

        [NativeTypeName("ma_bool32")]
        public uint duplicateChannels;
    }

    public unsafe partial struct ma_noise
    {
        public ma_data_source_vtable ds;

        public ma_noise_config config;

        public ma_lcg lcg;

        [NativeTypeName("union (anonymous union at miniaudio/vendor/miniaudio.h:9929:5)")]
        public _state_e__Union state;

        public void* _pHeap;

        [NativeTypeName("ma_bool32")]
        public uint _ownsHeap;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _state_e__Union
        {
            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:9931:9)")]
            public _pink_e__Struct pink;

            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:9937:9)")]
            public _brownian_e__Struct brownian;

            public unsafe partial struct _pink_e__Struct
            {
                public double** bin;

                public double* accumulation;

                [NativeTypeName("ma_uint32 *")]
                public uint* counter;
            }

            public unsafe partial struct _brownian_e__Struct
            {
                public double* accumulation;
            }
        }
    }

    public enum ma_resource_manager_data_source_flags
    {
        MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_STREAM = 0x00000001,
        MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_DECODE = 0x00000002,
        MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_ASYNC = 0x00000004,
        MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_WAIT_INIT = 0x00000008,
        MA_RESOURCE_MANAGER_DATA_SOURCE_FLAG_UNKNOWN_LENGTH = 0x00000010,
    }

    public unsafe partial struct ma_resource_manager_pipeline_stage_notification
    {
        [NativeTypeName("ma_async_notification *")]
        public void* pNotification;

        public ma_fence* pFence;
    }

    public partial struct ma_resource_manager_pipeline_notifications
    {
        public ma_resource_manager_pipeline_stage_notification init;

        public ma_resource_manager_pipeline_stage_notification done;
    }

    public enum ma_resource_manager_flags
    {
        MA_RESOURCE_MANAGER_FLAG_NON_BLOCKING = 0x00000001,
        MA_RESOURCE_MANAGER_FLAG_NO_THREADING = 0x00000002,
    }

    public unsafe partial struct ma_resource_manager_data_source_config
    {
        [NativeTypeName("const char *")]
        public sbyte* pFilePath;

        [NativeTypeName("const wchar_t *")]
        public ushort* pFilePathW;

        [NativeTypeName("const ma_resource_manager_pipeline_notifications *")]
        public ma_resource_manager_pipeline_notifications* pNotifications;

        [NativeTypeName("ma_uint64")]
        public ulong initialSeekPointInPCMFrames;

        [NativeTypeName("ma_uint64")]
        public ulong rangeBegInPCMFrames;

        [NativeTypeName("ma_uint64")]
        public ulong rangeEndInPCMFrames;

        [NativeTypeName("ma_uint64")]
        public ulong loopPointBegInPCMFrames;

        [NativeTypeName("ma_uint64")]
        public ulong loopPointEndInPCMFrames;

        [NativeTypeName("ma_bool32")]
        public uint isLooping;

        [NativeTypeName("ma_uint32")]
        public uint flags;
    }

    public enum ma_resource_manager_data_supply_type
    {
        ma_resource_manager_data_supply_type_unknown = 0,
        ma_resource_manager_data_supply_type_encoded,
        ma_resource_manager_data_supply_type_decoded,
        ma_resource_manager_data_supply_type_decoded_paged,
    }

    public partial struct ma_resource_manager_data_supply
    {
        public ma_resource_manager_data_supply_type type;

        [NativeTypeName("union (anonymous union at miniaudio/vendor/miniaudio.h:10070:5)")]
        public _backend_e__Union backend;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _backend_e__Union
        {
            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:10072:9)")]
            public _encoded_e__Struct encoded;

            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:10077:9)")]
            public _decoded_e__Struct decoded;

            [FieldOffset(0)]
            [NativeTypeName("struct (anonymous struct at miniaudio/vendor/miniaudio.h:10086:9)")]
            public _decodedPaged_e__Struct decodedPaged;

            public unsafe partial struct _encoded_e__Struct
            {
                [NativeTypeName("const void *")]
                public void* pData;

                [NativeTypeName("size_t")]
                public nuint sizeInBytes;
            }

            public unsafe partial struct _decoded_e__Struct
            {
                [NativeTypeName("const void *")]
                public void* pData;

                [NativeTypeName("ma_uint64")]
                public ulong totalFrameCount;

                [NativeTypeName("ma_uint64")]
                public ulong decodedFrameCount;

                public ma_format format;

                [NativeTypeName("ma_uint32")]
                public uint channels;

                [NativeTypeName("ma_uint32")]
                public uint sampleRate;
            }

            public partial struct _decodedPaged_e__Struct
            {
                public ma_paged_audio_buffer_data data;

                [NativeTypeName("ma_uint64")]
                public ulong decodedFrameCount;

                [NativeTypeName("ma_uint32")]
                public uint sampleRate;
            }
        }
    }

    public unsafe partial struct ma_resource_manager_data_buffer_node
    {
        [NativeTypeName("ma_uint32")]
        public uint hashedName32;

        [NativeTypeName("ma_uint32")]
        public uint refCount;

        public ma_result result;

        [NativeTypeName("ma_uint32")]
        public uint executionCounter;

        [NativeTypeName("ma_uint32")]
        public uint executionPointer;

        [NativeTypeName("ma_bool32")]
        public uint isDataOwnedByResourceManager;

        public ma_resource_manager_data_supply data;

        public ma_resource_manager_data_buffer_node* pParent;

        public ma_resource_manager_data_buffer_node* pChildLo;

        public ma_resource_manager_data_buffer_node* pChildHi;
    }

    public unsafe partial struct ma_resource_manager_data_buffer
    {
        public ma_data_source_base ds;

        public ma_resource_manager* pResourceManager;

        public ma_resource_manager_data_buffer_node* pNode;

        [NativeTypeName("ma_uint32")]
        public uint flags;

        [NativeTypeName("ma_uint32")]
        public uint executionCounter;

        [NativeTypeName("ma_uint32")]
        public uint executionPointer;

        [NativeTypeName("ma_uint64")]
        public ulong seekTargetInPCMFrames;

        [NativeTypeName("ma_bool32")]
        public uint seekToCursorOnNextRead;

        public ma_result result;

        [NativeTypeName("ma_bool32")]
        public uint isLooping;

        [NativeTypeName("ma_bool32")]
        public uint isConnectorInitialized;

        [NativeTypeName("union (anonymous union at miniaudio/vendor/miniaudio.h:10122:5)")]
        public _connector_e__Union connector;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _connector_e__Union
        {
            [FieldOffset(0)]
            public ma_decoder decoder;

            [FieldOffset(0)]
            public ma_audio_buffer buffer;

            [FieldOffset(0)]
            public ma_paged_audio_buffer pagedBuffer;
        }
    }

    public unsafe partial struct ma_resource_manager_data_stream
    {
        public ma_data_source_base ds;

        public ma_resource_manager* pResourceManager;

        [NativeTypeName("ma_uint32")]
        public uint flags;

        public ma_decoder decoder;

        [NativeTypeName("ma_bool32")]
        public uint isDecoderInitialized;

        [NativeTypeName("ma_uint64")]
        public ulong totalLengthInPCMFrames;

        [NativeTypeName("ma_uint32")]
        public uint relativeCursor;

        [NativeTypeName("ma_uint64")]
        public ulong absoluteCursor;

        [NativeTypeName("ma_uint32")]
        public uint currentPageIndex;

        [NativeTypeName("ma_uint32")]
        public uint executionCounter;

        [NativeTypeName("ma_uint32")]
        public uint executionPointer;

        [NativeTypeName("ma_bool32")]
        public uint isLooping;

        public void* pPageData;

        [NativeTypeName("ma_uint32 [2]")]
        public fixed uint pageFrameCount[2];

        public ma_result result;

        [NativeTypeName("ma_bool32")]
        public uint isDecoderAtEnd;

        [NativeTypeName("ma_bool32 [2]")]
        public fixed uint isPageValid[2];

        [NativeTypeName("ma_bool32")]
        public uint seekCounter;
    }

    public partial struct ma_resource_manager_data_source
    {
        [NativeTypeName("union (anonymous union at miniaudio/vendor/miniaudio.h:10160:5)")]
        public _backend_e__Union backend;

        [NativeTypeName("ma_uint32")]
        public uint flags;

        [NativeTypeName("ma_uint32")]
        public uint executionCounter;

        [NativeTypeName("ma_uint32")]
        public uint executionPointer;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _backend_e__Union
        {
            [FieldOffset(0)]
            public ma_resource_manager_data_buffer buffer;

            [FieldOffset(0)]
            public ma_resource_manager_data_stream stream;
        }
    }

    public unsafe partial struct ma_resource_manager_config
    {
        public ma_allocation_callbacks allocationCallbacks;

        public ma_log* pLog;

        public ma_format decodedFormat;

        [NativeTypeName("ma_uint32")]
        public uint decodedChannels;

        [NativeTypeName("ma_uint32")]
        public uint decodedSampleRate;

        [NativeTypeName("ma_uint32")]
        public uint jobThreadCount;

        [NativeTypeName("ma_uint32")]
        public uint jobQueueCapacity;

        [NativeTypeName("ma_uint32")]
        public uint flags;

        [NativeTypeName("ma_vfs *")]
        public void* pVFS;

        public ma_decoding_backend_vtable** ppCustomDecodingBackendVTables;

        [NativeTypeName("ma_uint32")]
        public uint customDecodingBackendCount;

        public void* pCustomDecodingBackendUserData;
    }

    public unsafe partial struct ma_resource_manager
    {
        public ma_resource_manager_config config;

        public ma_resource_manager_data_buffer_node* pRootDataBufferNode;

        [NativeTypeName("ma_mutex")]
        public void* dataBufferBSTLock;

        [NativeTypeName("ma_thread [64]")]
        public _jobThreads_e__FixedBuffer jobThreads;

        public ma_job_queue jobQueue;

        public ma_default_vfs defaultVFS;

        public ma_log log;

        public unsafe partial struct _jobThreads_e__FixedBuffer
        {
            public void* e0;
            public void* e1;
            public void* e2;
            public void* e3;
            public void* e4;
            public void* e5;
            public void* e6;
            public void* e7;
            public void* e8;
            public void* e9;
            public void* e10;
            public void* e11;
            public void* e12;
            public void* e13;
            public void* e14;
            public void* e15;
            public void* e16;
            public void* e17;
            public void* e18;
            public void* e19;
            public void* e20;
            public void* e21;
            public void* e22;
            public void* e23;
            public void* e24;
            public void* e25;
            public void* e26;
            public void* e27;
            public void* e28;
            public void* e29;
            public void* e30;
            public void* e31;
            public void* e32;
            public void* e33;
            public void* e34;
            public void* e35;
            public void* e36;
            public void* e37;
            public void* e38;
            public void* e39;
            public void* e40;
            public void* e41;
            public void* e42;
            public void* e43;
            public void* e44;
            public void* e45;
            public void* e46;
            public void* e47;
            public void* e48;
            public void* e49;
            public void* e50;
            public void* e51;
            public void* e52;
            public void* e53;
            public void* e54;
            public void* e55;
            public void* e56;
            public void* e57;
            public void* e58;
            public void* e59;
            public void* e60;
            public void* e61;
            public void* e62;
            public void* e63;

            public ref void* this[int index]
            {
                get
                {
                    fixed (void** pThis = &e0)
                    {
                        return ref pThis[index];
                    }
                }
            }
        }
    }

    public enum ma_node_flags
    {
        MA_NODE_FLAG_PASSTHROUGH = 0x00000001,
        MA_NODE_FLAG_CONTINUOUS_PROCESSING = 0x00000002,
        MA_NODE_FLAG_ALLOW_NULL_INPUT = 0x00000004,
        MA_NODE_FLAG_DIFFERENT_PROCESSING_RATES = 0x00000008,
        MA_NODE_FLAG_SILENT_OUTPUT = 0x00000010,
    }

    public enum ma_node_state
    {
        ma_node_state_started = 0,
        ma_node_state_stopped = 1,
    }

    public unsafe partial struct ma_node_vtable
    {
        [NativeTypeName("void (*)(ma_node *, const float **, ma_uint32 *, float **, ma_uint32 *)")]
        public delegate* unmanaged[Cdecl]<void*, float**, uint*, float**, uint*, void> onProcess;

        [NativeTypeName("ma_result (*)(ma_node *, ma_uint32, ma_uint32 *)")]
        public delegate* unmanaged[Cdecl]<void*, uint, uint*, ma_result> onGetRequiredInputFrameCount;

        [NativeTypeName("ma_uint8")]
        public byte inputBusCount;

        [NativeTypeName("ma_uint8")]
        public byte outputBusCount;

        [NativeTypeName("ma_uint32")]
        public uint flags;
    }

    public unsafe partial struct ma_node_config
    {
        [NativeTypeName("const ma_node_vtable *")]
        public ma_node_vtable* vtable;

        public ma_node_state initialState;

        [NativeTypeName("ma_uint32")]
        public uint inputBusCount;

        [NativeTypeName("ma_uint32")]
        public uint outputBusCount;

        [NativeTypeName("const ma_uint32 *")]
        public uint* pInputChannels;

        [NativeTypeName("const ma_uint32 *")]
        public uint* pOutputChannels;
    }

    public unsafe partial struct ma_node_output_bus
    {
        [NativeTypeName("ma_node *")]
        public void* pNode;

        [NativeTypeName("ma_uint8")]
        public byte outputBusIndex;

        [NativeTypeName("ma_uint8")]
        public byte channels;

        [NativeTypeName("ma_uint8")]
        public byte inputNodeInputBusIndex;

        [NativeTypeName("ma_uint32")]
        public uint flags;

        [NativeTypeName("ma_uint32")]
        public uint refCount;

        [NativeTypeName("ma_bool32")]
        public uint isAttached;

        [NativeTypeName("ma_spinlock")]
        public uint @lock;

        public float volume;

        public ma_node_output_bus* pNext;

        public ma_node_output_bus* pPrev;

        [NativeTypeName("ma_node *")]
        public void* pInputNode;
    }

    public partial struct ma_node_input_bus
    {
        public ma_node_output_bus head;

        [NativeTypeName("ma_uint32")]
        public uint nextCounter;

        [NativeTypeName("ma_spinlock")]
        public uint @lock;

        [NativeTypeName("ma_uint8")]
        public byte channels;
    }

    public unsafe partial struct ma_node_base
    {
        public ma_node_graph* pNodeGraph;

        [NativeTypeName("const ma_node_vtable *")]
        public ma_node_vtable* vtable;

        public float* pCachedData;

        [NativeTypeName("ma_uint16")]
        public ushort cachedDataCapInFramesPerBus;

        [NativeTypeName("ma_uint16")]
        public ushort cachedFrameCountOut;

        [NativeTypeName("ma_uint16")]
        public ushort cachedFrameCountIn;

        [NativeTypeName("ma_uint16")]
        public ushort consumedFrameCountIn;

        public ma_node_state state;

        [NativeTypeName("ma_uint64 [2]")]
        public fixed ulong stateTimes[2];

        [NativeTypeName("ma_uint64")]
        public ulong localTime;

        [NativeTypeName("ma_uint32")]
        public uint inputBusCount;

        [NativeTypeName("ma_uint32")]
        public uint outputBusCount;

        public ma_node_input_bus* pInputBuses;

        public ma_node_output_bus* pOutputBuses;

        [NativeTypeName("ma_node_input_bus [2]")]
        public __inputBuses_e__FixedBuffer _inputBuses;

        [NativeTypeName("ma_node_output_bus [2]")]
        public __outputBuses_e__FixedBuffer _outputBuses;

        public void* _pHeap;

        [NativeTypeName("ma_bool32")]
        public uint _ownsHeap;

        public partial struct __inputBuses_e__FixedBuffer
        {
            public ma_node_input_bus e0;
            public ma_node_input_bus e1;

            public ref ma_node_input_bus this[int index]
            {
                get
                {
                    return ref AsSpan()[index];
                }
            }

            public Span<ma_node_input_bus> AsSpan() => MemoryMarshal.CreateSpan(ref e0, 2);
        }

        public partial struct __outputBuses_e__FixedBuffer
        {
            public ma_node_output_bus e0;
            public ma_node_output_bus e1;

            public ref ma_node_output_bus this[int index]
            {
                get
                {
                    return ref AsSpan()[index];
                }
            }

            public Span<ma_node_output_bus> AsSpan() => MemoryMarshal.CreateSpan(ref e0, 2);
        }
    }

    public partial struct ma_node_graph_config
    {
        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint16")]
        public ushort nodeCacheCapInFrames;
    }

    public partial struct ma_node_graph
    {
        public ma_node_base @base;

        public ma_node_base endpoint;

        [NativeTypeName("ma_uint16")]
        public ushort nodeCacheCapInFrames;

        [NativeTypeName("ma_bool32")]
        public uint isReading;
    }

    public unsafe partial struct ma_data_source_node_config
    {
        public ma_node_config nodeConfig;

        [NativeTypeName("ma_data_source *")]
        public void* pDataSource;
    }

    public unsafe partial struct ma_data_source_node
    {
        public ma_node_base @base;

        [NativeTypeName("ma_data_source *")]
        public void* pDataSource;
    }

    public partial struct ma_splitter_node_config
    {
        public ma_node_config nodeConfig;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint outputBusCount;
    }

    public partial struct ma_splitter_node
    {
        public ma_node_base @base;
    }

    public partial struct ma_biquad_node_config
    {
        public ma_node_config nodeConfig;

        public ma_biquad_config biquad;
    }

    public partial struct ma_biquad_node
    {
        public ma_node_base baseNode;

        public ma_biquad biquad;
    }

    public partial struct ma_lpf_node_config
    {
        public ma_node_config nodeConfig;

        public ma_lpf_config lpf;
    }

    public partial struct ma_lpf_node
    {
        public ma_node_base baseNode;

        public ma_lpf lpf;
    }

    public partial struct ma_hpf_node_config
    {
        public ma_node_config nodeConfig;

        public ma_hpf_config hpf;
    }

    public partial struct ma_hpf_node
    {
        public ma_node_base baseNode;

        public ma_hpf hpf;
    }

    public partial struct ma_bpf_node_config
    {
        public ma_node_config nodeConfig;

        public ma_bpf_config bpf;
    }

    public partial struct ma_bpf_node
    {
        public ma_node_base baseNode;

        public ma_bpf bpf;
    }

    public partial struct ma_notch_node_config
    {
        public ma_node_config nodeConfig;

        [NativeTypeName("ma_notch_config")]
        public ma_notch2_config notch;
    }

    public partial struct ma_notch_node
    {
        public ma_node_base baseNode;

        public ma_notch2 notch;
    }

    public partial struct ma_peak_node_config
    {
        public ma_node_config nodeConfig;

        [NativeTypeName("ma_peak_config")]
        public ma_peak2_config peak;
    }

    public partial struct ma_peak_node
    {
        public ma_node_base baseNode;

        public ma_peak2 peak;
    }

    public partial struct ma_loshelf_node_config
    {
        public ma_node_config nodeConfig;

        [NativeTypeName("ma_loshelf_config")]
        public ma_loshelf2_config loshelf;
    }

    public partial struct ma_loshelf_node
    {
        public ma_node_base baseNode;

        public ma_loshelf2 loshelf;
    }

    public partial struct ma_hishelf_node_config
    {
        public ma_node_config nodeConfig;

        [NativeTypeName("ma_hishelf_config")]
        public ma_hishelf2_config hishelf;
    }

    public partial struct ma_hishelf_node
    {
        public ma_node_base baseNode;

        public ma_hishelf2 hishelf;
    }

    public partial struct ma_delay_node_config
    {
        public ma_node_config nodeConfig;

        public ma_delay_config delay;
    }

    public partial struct ma_delay_node
    {
        public ma_node_base baseNode;

        public ma_delay delay;
    }

    public enum ma_sound_flags
    {
        MA_SOUND_FLAG_STREAM = 0x00000001,
        MA_SOUND_FLAG_DECODE = 0x00000002,
        MA_SOUND_FLAG_ASYNC = 0x00000004,
        MA_SOUND_FLAG_WAIT_INIT = 0x00000008,
        MA_SOUND_FLAG_NO_DEFAULT_ATTACHMENT = 0x00000010,
        MA_SOUND_FLAG_NO_PITCH = 0x00000020,
        MA_SOUND_FLAG_NO_SPATIALIZATION = 0x00000040,
    }

    public enum ma_engine_node_type
    {
        ma_engine_node_type_sound,
        ma_engine_node_type_group,
    }

    public unsafe partial struct ma_engine_node_config
    {
        public ma_engine* pEngine;

        public ma_engine_node_type type;

        [NativeTypeName("ma_uint32")]
        public uint channelsIn;

        [NativeTypeName("ma_uint32")]
        public uint channelsOut;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        public ma_mono_expansion_mode monoExpansionMode;

        [NativeTypeName("ma_bool8")]
        public byte isPitchDisabled;

        [NativeTypeName("ma_bool8")]
        public byte isSpatializationDisabled;

        [NativeTypeName("ma_uint8")]
        public byte pinnedListenerIndex;
    }

    public unsafe partial struct ma_engine_node
    {
        public ma_node_base baseNode;

        public ma_engine* pEngine;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        public ma_mono_expansion_mode monoExpansionMode;

        public ma_fader fader;

        public ma_linear_resampler resampler;

        public ma_spatializer spatializer;

        public ma_panner panner;

        public float pitch;

        public float oldPitch;

        public float oldDopplerPitch;

        [NativeTypeName("ma_bool32")]
        public uint isPitchDisabled;

        [NativeTypeName("ma_bool32")]
        public uint isSpatializationDisabled;

        [NativeTypeName("ma_uint32")]
        public uint pinnedListenerIndex;

        [NativeTypeName("ma_bool8")]
        public byte _ownsHeap;

        public void* _pHeap;
    }

    public unsafe partial struct ma_sound_config
    {
        [NativeTypeName("const char *")]
        public sbyte* pFilePath;

        [NativeTypeName("const wchar_t *")]
        public ushort* pFilePathW;

        [NativeTypeName("ma_data_source *")]
        public void* pDataSource;

        [NativeTypeName("ma_node *")]
        public void* pInitialAttachment;

        [NativeTypeName("ma_uint32")]
        public uint initialAttachmentInputBusIndex;

        [NativeTypeName("ma_uint32")]
        public uint channelsIn;

        [NativeTypeName("ma_uint32")]
        public uint channelsOut;

        public ma_mono_expansion_mode monoExpansionMode;

        [NativeTypeName("ma_uint32")]
        public uint flags;

        [NativeTypeName("ma_uint64")]
        public ulong initialSeekPointInPCMFrames;

        [NativeTypeName("ma_uint64")]
        public ulong rangeBegInPCMFrames;

        [NativeTypeName("ma_uint64")]
        public ulong rangeEndInPCMFrames;

        [NativeTypeName("ma_uint64")]
        public ulong loopPointBegInPCMFrames;

        [NativeTypeName("ma_uint64")]
        public ulong loopPointEndInPCMFrames;

        [NativeTypeName("ma_bool32")]
        public uint isLooping;

        public ma_fence* pDoneFence;
    }

    public unsafe partial struct ma_sound
    {
        public ma_engine_node engineNode;

        [NativeTypeName("ma_data_source *")]
        public void* pDataSource;

        [NativeTypeName("ma_uint64")]
        public ulong seekTarget;

        [NativeTypeName("ma_bool32")]
        public uint atEnd;

        [NativeTypeName("ma_bool8")]
        public byte ownsDataSource;

        public ma_resource_manager_data_source* pResourceManagerDataSource;
    }

    public unsafe partial struct ma_sound_inlined
    {
        public ma_sound sound;

        public ma_sound_inlined* pNext;

        public ma_sound_inlined* pPrev;
    }

    public unsafe partial struct ma_engine_config
    {
        public ma_resource_manager* pResourceManager;

        public ma_context* pContext;

        public ma_device* pDevice;

        public ma_device_id* pPlaybackDeviceID;

        [NativeTypeName("ma_device_notification_proc")]
        public delegate* unmanaged[Cdecl]<ma_device_notification*, void> notificationCallback;

        public ma_log* pLog;

        [NativeTypeName("ma_uint32")]
        public uint listenerCount;

        [NativeTypeName("ma_uint32")]
        public uint channels;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        [NativeTypeName("ma_uint32")]
        public uint periodSizeInFrames;

        [NativeTypeName("ma_uint32")]
        public uint periodSizeInMilliseconds;

        [NativeTypeName("ma_uint32")]
        public uint gainSmoothTimeInFrames;

        [NativeTypeName("ma_uint32")]
        public uint gainSmoothTimeInMilliseconds;

        public ma_allocation_callbacks allocationCallbacks;

        [NativeTypeName("ma_bool32")]
        public uint noAutoStart;

        [NativeTypeName("ma_bool32")]
        public uint noDevice;

        public ma_mono_expansion_mode monoExpansionMode;

        [NativeTypeName("ma_vfs *")]
        public void* pResourceManagerVFS;
    }

    public unsafe partial struct ma_engine
    {
        public ma_node_graph nodeGraph;

        public ma_resource_manager* pResourceManager;

        public ma_device* pDevice;

        public ma_log* pLog;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        [NativeTypeName("ma_uint32")]
        public uint listenerCount;

        [NativeTypeName("ma_spatializer_listener [4]")]
        public _listeners_e__FixedBuffer listeners;

        public ma_allocation_callbacks allocationCallbacks;

        [NativeTypeName("ma_bool8")]
        public byte ownsResourceManager;

        [NativeTypeName("ma_bool8")]
        public byte ownsDevice;

        [NativeTypeName("ma_spinlock")]
        public uint inlinedSoundLock;

        public ma_sound_inlined* pInlinedSoundHead;

        [NativeTypeName("ma_uint32")]
        public uint inlinedSoundCount;

        [NativeTypeName("ma_uint32")]
        public uint gainSmoothTimeInFrames;

        public ma_mono_expansion_mode monoExpansionMode;

        public partial struct _listeners_e__FixedBuffer
        {
            public ma_spatializer_listener e0;
            public ma_spatializer_listener e1;
            public ma_spatializer_listener e2;
            public ma_spatializer_listener e3;

            public ref ma_spatializer_listener this[int index]
            {
                get
                {
                    return ref AsSpan()[index];
                }
            }

            public Span<ma_spatializer_listener> AsSpan() => MemoryMarshal.CreateSpan(ref e0, 4);
        }
    }
}