using System;

namespace CyberSecurityBot
{
    public static class UI
    {
        public static void DisplayBanner()
        {
            Console.Clear();
            // Top spacing
            Console.WriteLine("\n\n");

            // Border
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("╔══════════════════════════════════════════════╗");
            Console.WriteLine("║                                              ║");

            // Title
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("║        ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("CYBER SECURITY AWARENESS BOT");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("        ║");

            // Subtitle
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("║          Stay Safe • Stay Smart 🔐           ║");

            // Empty line
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("║                                              ║");

            // Bottom border
            Console.WriteLine("╚══════════════════════════════════════════════╝");

            Console.ResetColor();

            // Extra spacing
            Console.WriteLine("\n");
        }
    }
}
