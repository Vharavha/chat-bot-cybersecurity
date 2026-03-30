using System;

namespace CyberSecurityBot
{
    public static class ChatBot
    {
        public static void Start()
        {
            Console.WriteLine("Type a command (type 'help' to see options):");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("> ");
                Console.ResetColor();

                string input = Console.ReadLine()?.ToLower() ?? string.Empty;

                switch (input)
                {
                    case "help":
                        ShowHelp();
                        break;

                    case "password":
                        Console.WriteLine("Use strong passwords with numbers, symbols, and uppercase letters.");
                        break;

                    case "phishing":
                        Console.WriteLine("Do not click suspicious links. Always verify the sender.");
                        break;

                    case "malware":
                        Console.WriteLine("Install antivirus software and avoid downloading unknown files.");
                        break;

                    case "privacy":
                        Console.WriteLine("Never share personal information on unsafe websites.");
                        break;

                    case "exit":
                        Console.WriteLine("Goodbye 👋");
                        return;

                    default:
                        Console.WriteLine("Unknown command. Type 'help'.");
                        break;
                }
            }
        }

        private static void ShowHelp()
        {
            Console.WriteLine("\nAvailable Commands:");
            Console.WriteLine("help      - Show commands");
            Console.WriteLine("password  - Password tips");
            Console.WriteLine("phishing  - Phishing info");
            Console.WriteLine("malware   - Malware info");
            Console.WriteLine("privacy   - Privacy tips");
            Console.WriteLine("exit      - Exit program\n");
        }
    }
}
