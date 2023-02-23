using System;

namespace RIQAudioTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RIQAudio riq = new RIQAudio();
            Console.ReadLine();
            riq.Dispose();
            Console.ReadLine();
        }
    }
}
