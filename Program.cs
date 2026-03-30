using System;

namespace CyberSecurityBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CyberSecurity Awareness Bot";

            UI.DisplayBanner();
            VoiceGreeting.PlayGreeting();

            ChatBot.Start();
        }
    }
}
