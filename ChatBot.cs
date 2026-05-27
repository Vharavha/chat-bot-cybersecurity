using System;
<<<<<<< HEAD
using System.Collections.Generic;

namespace CyberSecurityBot
{
    public class ChatBot
    {
        private Dictionary<string, List<string>> keywordResponses;

        private string lastTopic = "";
        private string userName = "";
        private string favouriteTopic = "";

        public ChatBot()
        {
            keywordResponses = new Dictionary<string, List<string>>()
            {
                {
                    "password",
                    new List<string>()
                    {
                        "Use strong passwords with uppercase letters, numbers, and symbols.",
                        "Avoid using birthdays or names in your passwords.",
                        "Use a different password for every account."
                    }
                },

                {
                    "phishing",
                    new List<string>()
                    {
                        "Never click suspicious email links from unknown senders.",
                        "Scammers often pretend to be trusted companies.",
                        "Always verify email addresses before opening attachments."
                    }
                },

                {
                    "privacy",
                    new List<string>()
                    {
                        "Review your social media privacy settings regularly.",
                        "Avoid sharing personal information on unsafe websites.",
                        "Enable two-factor authentication to improve privacy."
                    }
                },

                {
                    "scam",
                    new List<string>()
                    {
                        "Never send money to strangers online.",
                        "Scammers often create fake urgency to pressure victims.",
                        "Be careful of fake competitions and giveaways."
                    }
                }
            };
        }

        public string GetResponse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "Please type a message.";
            }

            input = input.ToLower();

            // Greetings
            if (input.Contains("hello") || input.Contains("hi"))
            {
                return "Hello! How can I help you stay safe online today?";
            }

            // Help Command
            if (input.Contains("help"))
            {
                return "You can ask me about passwords, phishing, scams, or privacy.";
            }

            // Memory Feature - Name
            if (input.Contains("my name is"))
            {
                userName = input.Replace("my name is", "").Trim();

                return $"Nice to meet you, {userName}!";
            }

            // Memory Feature - Favourite Topic
            if (input.Contains("i like"))
            {
                favouriteTopic = input.Replace("i like", "").Trim();

                return $"Great! I'll remember that you're interested in {favouriteTopic}.";
            }

            // Sentiment Detection
            if (input.Contains("worried"))
            {
                return "It's understandable to feel worried about cybersecurity threats. Let me share some tips to help you stay safe online.";
            }

            if (input.Contains("frustrated"))
            {
                return "I understand this can feel frustrating. Cybersecurity can be confusing at first, but you're learning step by step.";
            }

            if (input.Contains("curious"))
            {
                return "Curiosity is excellent in cybersecurity. The more you learn, the safer you become online.";
            }

            // Follow-up Conversation
            if (input.Contains("tell me more") ||
                input.Contains("another tip") ||
                input.Contains("explain more"))
            {
                if (lastTopic != "")
                {
                    return GetRandomResponse(lastTopic);
                }
                else
                {
                    return "Please ask about a cybersecurity topic first.";
                }
            }

            // Keyword Recognition
            foreach (var keyword in keywordResponses.Keys)
            {
                if (input.Contains(keyword))
                {
                    lastTopic = keyword;

                    string response = GetRandomResponse(keyword);

                    // Personalised Memory Response
                    if (favouriteTopic == keyword)
                    {
                        response += $" Since you're interested in {keyword}, you should continue learning advanced protection tips.";
                    }

                    // Personalised Name Response
                    if (!string.IsNullOrEmpty(userName))
                    {
                        response = userName + ", " + response;
                    }

                    return response;
                }
            }

            // Default Response
            return "I'm not sure I understand. Can you try rephrasing?";
        }

        private string GetRandomResponse(string keyword)
        {
            Random random = new Random();

            List<string> responses = keywordResponses[keyword];

            int index = random.Next(responses.Count);

            return responses[index];
        }
    }
}
=======

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
>>>>>>> a4b6bca4c01d440131b4c0a66f8dc7259a65f32a
