using System.Runtime.InteropServices;

namespace RIQAudioSharp
{
    internal class Program
    {
        [DllImport("RIQAudio.dll", EntryPoint = "playTest")]
        static extern void playTest(string message);

        static void Main(string[] args)
        {
            playTest(@"C:\Users\Braedon\Music\youmademefallinlove.ogg");
        }
    }
}