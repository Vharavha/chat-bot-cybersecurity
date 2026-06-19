using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace CyberSecurityBot
{
    public partial class MainWindow : Window
    {
        private ChatBot bot;
        private DatabaseHelper db;
        private List<string> activityLog = new List<string>();
        private List<QuizQuestion> quizQuestions;
        private int currentQuestion = 0;
        private int score = 0;
        private bool quizRunning = false;

        public MainWindow()
        {
            InitializeComponent();

            bot = new ChatBot();
            db = new DatabaseHelper();
            quizQuestions = new List<QuizQuestion>()
{
    new QuizQuestion("What does 2FA stand for?", "two-factor authentication"),
    new QuizQuestion("Should you share your password? (yes/no)", "no"),
    new QuizQuestion("Is phishing a cyber attack? (yes/no)", "yes"),
    new QuizQuestion("Should you click suspicious links? (yes/no)", "no"),
    new QuizQuestion("What protects accounts besides passwords?", "2fa"),
    new QuizQuestion("Is public WiFi always safe? (yes/no)", "no"),
    new QuizQuestion("Should you update software regularly? (yes/no)", "yes"),
    new QuizQuestion("Do strong passwords improve security? (yes/no)", "yes"),
    new QuizQuestion("Should you verify email senders? (yes/no)", "yes"),
    new QuizQuestion("Can scams happen online? (yes/no)", "yes")
};
            VoiceGreeting.PlayGreeting();

            ChatArea.AppendText(
                "====================================================\n" +
                "      CYBER SECURITY AWARENESS BOT\n" +
                "====================================================\n\n" +
                "BOT: Welcome to the Cyber Security Awareness System.\n" +
                "BOT: Click a topic button below or type your own question.\n\n");

            ChatArea.ScrollToEnd();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        private void UserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendMessage();
            }
        }

        private void SendMessage()
        {
            string userMessage = UserInput.Text.Trim();

            if (quizRunning)
            {
                if (userMessage.ToLower() ==
                    quizQuestions[currentQuestion].Answer.ToLower())
                {
                    score++;
                    ChatArea.AppendText("BOT: Correct!\n\n");
                }
                else
                {
                    ChatArea.AppendText("BOT: Incorrect!\n\n");
                }

                currentQuestion++;

                if (currentQuestion >= quizQuestions.Count)
                {
                    quizRunning = false;

                    ChatArea.AppendText(
                        $"BOT: Quiz Finished!\n" +
                        $"Your Score: {score}/{quizQuestions.Count}\n\n");

                    activityLog.Add(
                        DateTime.Now.ToString("g") +
                        $" - Quiz Completed ({score}/{quizQuestions.Count})");

                    UserInput.Clear();
                    ChatArea.ScrollToEnd();
                    return;
                }

                ChatArea.AppendText(
                    quizQuestions[currentQuestion].Question + "\n\n");

                UserInput.Clear();
                ChatArea.ScrollToEnd();
                return;
            }

            if (string.IsNullOrWhiteSpace(userMessage))
                return;

            ChatArea.AppendText("YOU: " + userMessage + "\n");

            string response = bot.GetResponse(userMessage);

            ChatArea.AppendText("BOT: " + response + "\n\n");

            UserInput.Clear();
            UserInput.Focus();
            ChatArea.ScrollToEnd();
        }

        private void PasswordButton_Click(object sender, RoutedEventArgs e)
        {
            ChatArea.AppendText(
                "\n===== PASSWORD SAFETY =====\n\n" +
                "1. Use strong and unique passwords.\n" +
                "2. Include numbers, symbols, and mixed case.\n" +
                "3. Never reuse passwords across accounts.\n" +
                "4. Enable two-factor authentication whenever possible.\n" +
                "5. Use a password manager to store credentials.\n\n");

            ChatArea.ScrollToEnd();
        }

        private void PhishingButton_Click(object sender, RoutedEventArgs e)
        {
            ChatArea.AppendText(
                "\n===== PHISHING TIPS =====\n\n" +
                "1. Never click suspicious links.\n" +
                "2. Verify email senders.\n" +
                "3. Avoid unknown attachments.\n" +
                "4. Watch for spelling mistakes.\n" +
                "5. Check website URLs.\n" +
                "6. Report phishing emails.\n" +
                "7. Stay alert online.\n\n");

            ChatArea.ScrollToEnd();
        }

        private void PrivacyButton_Click(object sender, RoutedEventArgs e)
        {
            ChatArea.AppendText(
                "\n===== ONLINE PRIVACY =====\n\n" +
                "1. Protect personal information.\n" +
                "2. Use secure passwords.\n" +
                "3. Review privacy settings.\n" +
                "4. Avoid unsafe WiFi.\n" +
                "5. Use HTTPS websites.\n" +
                "6. Keep software updated.\n" +
                "7. Enable 2FA.\n\n");

            ChatArea.ScrollToEnd();
        }

        private void ScamButton_Click(object sender, RoutedEventArgs e)
        {
            ChatArea.AppendText(
                "\n===== ONLINE SCAMS =====\n\n" +
                "1. Never send money to strangers.\n" +
                "2. Verify companies first.\n" +
                "3. Ignore urgent payment requests.\n" +
                "4. Avoid fake giveaways.\n" +
                "5. Check website legitimacy.\n" +
                "6. Report scams.\n" +
                "7. Stay informed.\n\n");

            ChatArea.ScrollToEnd();
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            TaskItem task = new TaskItem()
            {
                Title = "Enable Two-Factor Authentication",
                Description = "Protect your accounts using 2FA.",
                ReminderDate = DateTime.Now.AddDays(7),
                IsCompleted = false
            };

            db.AddTask(task);

            activityLog.Add(
                DateTime.Now.ToString("g") +
                " - Task Added");

            ChatArea.AppendText(
                "\nBOT: Task added successfully.\n\n");

            ChatArea.ScrollToEnd();
        }

        private void ViewTasksButton_Click(object sender, RoutedEventArgs e)
        {
            List<TaskItem> tasks = db.GetTasks();

            ChatArea.AppendText(
                "\n===== TASK LIST =====\n");

            if (tasks.Count == 0)
            {
                ChatArea.AppendText(
                    "No tasks found.\n\n");

                return;
            }

            foreach (TaskItem task in tasks)
            {
                ChatArea.AppendText(
                    $"ID: {task.Id}\n" +
                    $"Title: {task.Title}\n" +
                    $"Description: {task.Description}\n" +
                    $"Completed: {task.IsCompleted}\n\n");
            }

            ChatArea.ScrollToEnd();
        }

        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            ChatArea.AppendText(
                "\nBOT: Delete feature is not implemented yet.\n" +
                "Please use the database tool or remove entries manually.\n\n");
            ChatArea.ScrollToEnd();
        }

        private void CompleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            int taskId = 1;

            db.CompleteTask(taskId);

            activityLog.Add(
                DateTime.Now.ToString("g") +
                " - Task Completed");

            ChatArea.AppendText(
                "\nBOT: Task completed successfully.\n\n");

            ChatArea.ScrollToEnd();
        }

        private void ActivityLogButton_Click(object sender, RoutedEventArgs e)
        {
            ChatArea.AppendText(
                "\n===== ACTIVITY LOG =====\n");

            if (activityLog.Count == 0)
            {
                ChatArea.AppendText(
                    "No activity recorded yet.\n\n");

                return;
            }

            foreach (string log in activityLog)
            {
                ChatArea.AppendText(log + "\n");
            }

            ChatArea.AppendText("\n");

            ChatArea.ScrollToEnd();
        }
        private void StartQuizButton_Click(object sender, RoutedEventArgs e)
        {
            currentQuestion = 0;
            score = 0;
            quizRunning = true;

            activityLog.Add(
                DateTime.Now.ToString("g") +
                " - Quiz Started");

            ChatArea.AppendText(
                "\n===== CYBERSECURITY QUIZ =====\n");

            ChatArea.AppendText(
                quizQuestions[currentQuestion].Question + "\n\n");
        }
    }
}