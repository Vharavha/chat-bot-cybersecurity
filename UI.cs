using System;

namespace CyberSecurityBot
{
    public static class UI
    {
        public static void DisplayBanner()
        {
            Console.Clear();

<<<<<<< HEAD
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
=======
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
>>>>>>> a4b6bca4c01d440131b4c0a66f8dc7259a65f32a
