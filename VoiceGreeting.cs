using System;
using System.IO;
using System.Media;

namespace CyberSecurityBot
{
    public static class VoiceGreeting
    {
        public static void PlayGreeting()
        {
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