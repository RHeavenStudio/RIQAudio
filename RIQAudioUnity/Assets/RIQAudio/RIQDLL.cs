using System;
using System.Runtime.InteropServices;

namespace RIQAudio
{
    public static class RIQDLL
    {
        public const string nativeLibName = "RIQAudio";

        [DllImport(nativeLibName)]
        public static extern AudioStream riq_init(string fileLocation);

        [DllImport(nativeLibName)]
        public static extern void riq_play();

        [DllImport(nativeLibName)]
        public static extern void riq_dispose(AudioStream stream);
    }

    [StructLayout(LayoutKind.Sequential)]
    public partial struct AudioStream
    {
        public IntPtr buffer;
    }
}
