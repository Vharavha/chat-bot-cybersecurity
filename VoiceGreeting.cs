using System;
using System.IO;
using System.Media;
<<<<<<< HEAD
=======
using System.Speech.Synthesis;
>>>>>>> a4b6bca4c01d440131b4c0a66f8dc7259a65f32a

namespace CyberSecurityBot
{
    public static class VoiceGreeting
    {
        public static void PlayGreeting()
        {
<<<<<<< HEAD
            try
            {
                string path = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Assets",
                    "greeting.wav"
                );

                SoundPlayer player = new SoundPlayer(path);

                player.Play();
            }
            catch
            {
            }
        }
    }
}
=======
            string message = "Hello! Welcome to the Cybersecurity Awareness Bot.";

            // 🔊 Play WAV if exists
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "greeting.wav");
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

            // 🗣 Text-to-Speech
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
>>>>>>> a4b6bca4c01d440131b4c0a66f8dc7259a65f32a
