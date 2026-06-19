using System;
using System.IO;
using System.Media;
using System.Speech.Synthesis;

namespace CyberSecurityBot
{
    public static class VoiceGreeting
    {
        public static void PlayGreeting()
        {
            string message = "Hello! Welcome to the Cybersecurity Awareness Bot.";

            // Try to play WAV from Assets
            try
            {
                string path = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Assets",
                    "greeting.wav"
                );

                if (File.Exists(path))
                {
                    using (SoundPlayer player = new SoundPlayer(path))
                    {
                        player.PlaySync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"(Audio playback failed: {ex.Message})");
            }

            // Text-to-Speech
            try
            {
                using (SpeechSynthesizer synth = new SpeechSynthesizer())
                {
                    synth.Speak(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"(Text-to-Speech not available: {ex.Message})");
            }

            Console.WriteLine(message);
            Console.WriteLine();
        }
    }
}
