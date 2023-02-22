using System;
using System.Runtime.InteropServices;

namespace RIQAudio
{
    public static class RIQDLL
    {
        public const string nativeLibName = "riqaudio";

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void riq_init_audio_device(string file);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void riq_close_audio_device();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool riq_is_ready();
    }

    [StructLayout(LayoutKind.Sequential)]
    public partial struct AudioStream
    {
        public IntPtr buffer;
    }
}
