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
        public static extern AudioStream riq_init();

        static void Main(string[] args)
        {
            var stream = riq_init();
            // playTest(@"C:\Users\Braedon\Music\youmademefallinlove.ogg");
        }
    }
}