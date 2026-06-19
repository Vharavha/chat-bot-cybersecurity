namespace CyberSecurityBot
{
    public class QuizQuestion
    {
        public string Question { get; set; }
        public string Answer { get; set; }

        public QuizQuestion(string question, string answer)
        {
            Question = question;
            Answer = answer;
        }
    }
}