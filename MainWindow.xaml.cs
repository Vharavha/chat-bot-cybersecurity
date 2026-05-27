using System.Windows;
using System.Windows.Input;

namespace CyberSecurityBot
{
    public partial class MainWindow : Window
    {
        private ChatBot bot;

        public MainWindow()
        {
            InitializeComponent();

            bot = new ChatBot();

            VoiceGreeting.PlayGreeting();

            ChatArea.AppendText(
                "====================================================\n" +
                "      CYBER SECURITY AWARENESS BOT\n" +
                "====================================================\n\n" +

                "BOT: Welcome to the Cyber Security Awareness System.\n" +
                "BOT: Click one of the topic buttons below or type your own question.\n\n"
            );

            ChatArea.ScrollToEnd();
        }

        // SEND BUTTON
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        // ENTER KEY
        private void UserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendMessage();
            }
        }

        // MAIN MESSAGE METHOD
        private void SendMessage()
        {
            string userMessage = UserInput.Text;

            if (string.IsNullOrWhiteSpace(userMessage))
            {
                return;
            }

            ChatArea.AppendText("YOU: " + userMessage + "\n");

            string response = bot.GetResponse(userMessage);

            ChatArea.AppendText("BOT: " + response + "\n\n");

            ChatArea.ScrollToEnd();

            UserInput.Clear();

            UserInput.Focus();
        }

        // PASSWORD BUTTON
        private void PasswordButton_Click(object sender, RoutedEventArgs e)
        {
            ChatArea.AppendText(
                "====================================================\n" +
                "PASSWORD SAFETY\n" +
                "====================================================\n\n" +

                "BOT: Password safety is one of the most important parts of cybersecurity.\n" +
                "BOT: Always create strong passwords using uppercase letters, lowercase letters, numbers, and symbols.\n" +
                "BOT: Avoid using personal information such as your name, birthday, or phone number.\n" +
                "BOT: Never use the same password for multiple accounts.\n" +
                "BOT: Change important passwords regularly to improve security.\n" +
                "BOT: Enable two-factor authentication whenever possible.\n" +
                "BOT: Password managers can help store passwords securely.\n" +
                "BOT: Never share your password with other people.\n\n"
            );

            ChatArea.ScrollToEnd();
        }

        // PHISHING BUTTON
        private void PhishingButton_Click(object sender, RoutedEventArgs e)
        {
            ChatArea.AppendText(
                "====================================================\n" +
                "PHISHING TIPS\n" +
                "====================================================\n\n" +

                "BOT: Phishing attacks attempt to steal personal information.\n" +
                "BOT: Be careful of suspicious emails asking for passwords or banking information.\n" +
                "BOT: Never click unknown links from strangers.\n" +
                "BOT: Check email addresses carefully before replying.\n" +
                "BOT: Scammers often pretend to be trusted companies or banks.\n" +
                "BOT: Avoid downloading unknown attachments.\n" +
                "BOT: Use antivirus software to improve protection.\n" +
                "BOT: Report suspicious emails immediately.\n\n"
            );

            ChatArea.ScrollToEnd();
        }

        // PRIVACY BUTTON
        private void PrivacyButton_Click(object sender, RoutedEventArgs e)
        {
            ChatArea.AppendText(
                "====================================================\n" +
                "ONLINE PRIVACY\n" +
                "====================================================\n\n" +

                "BOT: Online privacy protects your personal information from cybercriminals.\n" +
                "BOT: Avoid sharing sensitive information publicly online.\n" +
                "BOT: Review your social media privacy settings regularly.\n" +
                "BOT: Use secure websites that begin with HTTPS.\n" +
                "BOT: Avoid connecting to unsafe public WiFi networks.\n" +
                "BOT: Install antivirus and firewall software.\n" +
                "BOT: Keep your apps and devices updated.\n" +
                "BOT: Strong privacy habits reduce cyber risks.\n\n"
            );

            ChatArea.ScrollToEnd();
        }

        // SCAM BUTTON
        private void ScamButton_Click(object sender, RoutedEventArgs e)
        {
            ChatArea.AppendText(
                "====================================================\n" +
                "ONLINE SCAMS\n" +
                "====================================================\n\n" +

                "BOT: Online scams are becoming more advanced every year.\n" +
                "BOT: Never send money to strangers online.\n" +
                "BOT: Be careful of fake giveaways and fake job offers.\n" +
                "BOT: Scammers create fake websites to steal information.\n" +
                "BOT: Verify companies before making payments online.\n" +
                "BOT: Ignore messages demanding urgent payments.\n" +
                "BOT: Use secure payment methods whenever possible.\n" +
                "BOT: Report scams to cybersecurity authorities.\n\n"
            );

            ChatArea.ScrollToEnd();
        }
    }
}