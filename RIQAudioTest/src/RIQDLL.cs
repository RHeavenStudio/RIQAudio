using System;
using System.Runtime.InteropServices;

namespace RIQAudioTest
{
    public static class RIQDLL
    {
        public const string nativeLibName = "RIQAudio";

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RiqInitAudioDevice();

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void RiqCloseAudioDevice();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsRiqReady();
    }

    public partial class RIQAudio
    {

        [DllImport(RIQDLL.nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CreateRIQAudio();

        [DllImport(RIQDLL.nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern bool DeleteRIQAudio(IntPtr riq);

        private IntPtr _riqAudioPointer;

        public RIQAudio()
        {
            _riqAudioPointer = CreateRIQAudio();
        }

        ~RIQAudio()
        {
            DeleteRIQAudio(_riqAudioPointer);
        }
    }
}
