using System;
using System.Runtime.InteropServices;

namespace RIQAudio.Models
{
    public partial class RIQAudioDevice : IDisposable
    {
        [DllImport(RIQDLL.nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CreateRIQAudioDevice();

        [DllImport(RIQDLL.nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void DeleteRIQAudioDevice(IntPtr riq);

        private readonly IntPtr _riqAudioPointer;

        public RIQAudioDevice()
        {
            _riqAudioPointer = CreateRIQAudioDevice();
        }

        public void Dispose()
        {
            DeleteRIQAudioDevice(_riqAudioPointer);
        }
    }
}
