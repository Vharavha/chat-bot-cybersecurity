using System;

namespace CyberSecurityBot
{
    public static class UI
    {
        public static void DisplayBanner()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("=================================================");
            Console.WriteLine("         CYBER SECURITY AWARENESS BOT");
            Console.WriteLine("=================================================");

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Stay Safe • Stay Smart");
            Console.ResetColor();

            Console.WriteLine();
        }
    }
}