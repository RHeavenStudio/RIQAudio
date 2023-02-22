using System.Runtime.InteropServices;

namespace RIQAudioConsole
{
    internal class Program
    {
        public const string nativeLibName = "riqaudio";

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void riq_init_audio_device([MarshalAs(UnmanagedType.LPUTF8Str)] string file);

        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void riq_close_audio_device();
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool riq_is_ready();

        static void Main(string[] args)
        {
            riq_init_audio_device(@"Title Theme Finished.wav");
            // Console.WriteLine(riq_is_ready());
            Console.ReadLine();
            // riq_close_audio_device();
        }
    }
}