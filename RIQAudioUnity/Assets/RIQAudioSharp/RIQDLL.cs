using System;
using System.Runtime.InteropServices;

namespace RIQAudio
{
    public static class RIQDLL
    {
        public const string nativeLibName = "RIQAudio";

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern AudioStream riq_init(string fileLocation);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void riq_play();

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void riq_dispose(AudioStream stream);
    }

    [StructLayout(LayoutKind.Sequential)]
    public partial struct AudioStream
    {
        public IntPtr buffer;
    }
}
