using MoneyQuiz.Core;

namespace MoneyQuiz.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            AnswerController answerController = new AnswerController();
            LifelineController lifelineController = new LifelineController();
            PlayerController playerController = new PlayerController();
            QuestionController questionController = new QuestionController();

            Console.WriteLine("---------- ДОБРЕ ДОШЛИ В СТАНИ БОГАТ ----------");
            Console.WriteLine("1. Добавете въпрос");
            Console.WriteLine("2. Добавете 4 отговора на избран въпрос");
            Console.WriteLine("3. Редактирайте на въпрос по id");
            Console.WriteLine("4. Редактирайте на отговор по id");
            Console.WriteLine("5. Изтрийте жокер");
            Console.WriteLine("6. Добавете участник");
            Console.WriteLine("7. Изведете текста на въпросите за сума по-голяма от 3000 лв.");
            Console.WriteLine("8. Изведете текста на въпросите и всичките възможни отговори за всеки въпрос");
            Console.WriteLine("9. Изведете текста на въпроса и на верния отговор само за въпросите за посочена сума");

            string input = Console.ReadLine();

            while (true)
            {
                switch (input)
                {
                    case "1":
                        Console.Write("Въведи текст на въпроса: ");
                        string text = Console.ReadLine();

                        Console.Write("Въведи сума (лв.): ");
                        decimal amount = decimal.Parse(Console.ReadLine());

                        questionController.AddQuestion(text, amount);
                        break;

                    case "2":
                        Console.Write("Въведи ID на въпроса: ");
                        var questionId = int.Parse(Console.ReadLine());
                        for (int i = 1; i <= 4; i++)
                        {
                            Console.Write($"Отговор {i} текст: ");
                            var answerText = Console.ReadLine();

                            Console.Write($"Отговор {i} верен ли е (true/false): ");
                            var correct = bool.Parse(Console.ReadLine());

                            answerController.AddAnswerToQuestion(questionId, answerText, correct);
                        }
                        break;

                    case "3":
                        Console.Write("ID на въпроса за редакция: ");
                        int editQuestionId = int.Parse(Console.ReadLine());

                        Console.Write("Нов текст: ");
                        string newQuestionText = Console.ReadLine();

                        questionController.EditQuestion(editQuestionId, newQuestionText);
                        break;

                    case "4":
                        Console.Write("ID на отговора за редакция: ");
                        int editAnswerId = int.Parse(Console.ReadLine());

                        Console.Write("Нов текст: ");
                        string newAnswerText = Console.ReadLine();

                        Console.Write("Верeн ли е този отговор? (true/false): ");
                        bool newIsCorrect = bool.Parse(Console.ReadLine());

                        answerController.EditAnswer(editAnswerId, newAnswerText, newIsCorrect);
                        break;

                    case "5":
                        Console.Write("ID на жокера за изтриване: ");
                        int lifelineId = int.Parse(Console.ReadLine());

                        lifelineController.DeleteLifeline(lifelineId);
                        break;

                    case "6":
                        Console.Write("Въведи име на участник: ");
                        string playerName = Console.ReadLine();

                        playerController.AddPlayer(playerName);
                        break;

                    case "7":
                        questionController.PrintQuestionsAboveAmount();
                        break;

                    case "8":
                        questionController.PrintAllQuestionsWithAnswers();
                        break;

                    case "9":
                        Console.Write("Въведи сума (лв.): ");
                        decimal targetAmount = decimal.Parse(Console.ReadLine());

                        questionController.PrintCorrectAnswerForAmount(targetAmount);
                        break;

                    case "0":
                        Console.WriteLine("Изход");
                        return;

                    default:
                        Console.WriteLine("Невалиден избор.");
                        break;
                }

                Console.WriteLine();
                input = Console.ReadLine();
            }
          
        }
    }
}
