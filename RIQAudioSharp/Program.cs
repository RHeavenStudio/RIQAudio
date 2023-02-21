using System.Runtime.InteropServices;

namespace RIQAudioSharp
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct AudioStream
    {
        public IntPtr buffer;
    }

    internal class Program
    {
        public const string nativeLibName = "RIQAudio.dll";

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern AudioStream riq_init(string fileLocation);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void riq_play();

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void riq_dispose(AudioStream stream);


        static void Main(string[] args)
        {
            string streamURI = @"mudstep_atomicbeats_old.wav";
            var stream = riq_init(streamURI);

            riq_play();
            Console.ReadLine();

            riq_dispose(stream);
        }
    }
}