using System;

using RIQAudio.Models;

namespace RIQAudioTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RIQAudioDevice riq = new RIQAudioDevice();

            Console.ReadLine();

            riq.Dispose();

            Console.ReadLine();
        }
    }
}
