using System;
using System.Runtime.InteropServices;

namespace RIQAudio
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
}
