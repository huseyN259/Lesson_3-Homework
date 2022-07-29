using System;

class Program
{
    static void RandomMethod(string[] array)
    {
        Random random = new Random();

        for (int i = array.Length - 1; i > 0; i--)
        {
            int tempI = random.Next(i + 1);

            string tempS = array[i];
            array[i] = array[tempI];
            array[tempI] = tempS;
        }
    }

    static int getAnswer(int answerCount, string question, string[] answers)
    {
        int choice = 0;

        do
        {
            int questionNumber = 0;
            Console.WriteLine(question);

            foreach (var answer in answers)
                Console.WriteLine($"{++questionNumber}) {answer}");

            Console.Write("\nEnter your choice : ");
            int.TryParse(Console.ReadLine(), out choice);
            Console.WriteLine("\n");

        } while (choice < 1 || choice > answerCount);

        return choice;
    }

    static void check(string selected, string correct, ref int score)
    {
        if (correct == selected)
        {
            score += 10;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("===== TRUE");
        }
        else
        {
            score -= (score == 0) ? 0 : 10;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("===== FALSE");
        }

        Console.WriteLine(" answer =====");
    }

    static void Main()
    {
        string welcomeMessage = "========== WELCOME TO C# EXAM ==========";
        Console.WriteLine(welcomeMessage.PadLeft(75));

        int score = 0;
        const int questionCount = 10, answerCount = 3;

        string[] questions =
        {
            "Who is C#'s creator ?",
            "When was C# created ?",
            "How many part does .NET consist of ?",
            "What is CLR's opening ?",
            "What is difference between FRAMEWORK AND CORE ?",
            "Select row containing Misc Operators.",
            "How many part does JIT consist of ?",
            "How does the 'as' keyword ?",
            "How does the 'is' keyword ?",
            "What is int32 equal to ?"
        };

        string[][] answers = new string[questionCount][]
        {
            new string[answerCount]{ "Anders Hejlsberg",  "Bjarne Stroustrup", "Elon Musk" },
            new string[answerCount]{ "2002", "1972", "2016" },
            new string[answerCount]{ "2", "5", "3"},
            new string[answerCount]{ "Common Language Runtime", "I don't know", "Class Library" },
            new string[answerCount]{ "Framework only work WINDOWS OS, but CORE also works in other OS", "Both are programming language", "There is no difference" },
            new string[answerCount]{ "*, nameof, sizeof, typeof, ?:", "&, *, +", "typeof, >="},
            new string[answerCount]{ "3", "1", "4"},
            new string[answerCount]{ "Return null, if unable to cast", "Returns nothing", "I don't know" },
            new string[answerCount]{ "Return bool", "Return nullptr", "Return null" },
            new string[answerCount]{ "int", "short", "bool"}
        };

        for (int i = 0; i < questionCount; i++)
        {
            var correctAnswer = answers[i][0];
            RandomMethod(answers[i]);
            int choice = getAnswer(answerCount, questions[i], answers[i]);
            check(answers[i][choice - 1], correctAnswer, ref score);

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Press any key to continue...");
            Console.WriteLine("\n");
            Console.ReadKey();
        }

        Console.Clear();
        Console.WriteLine($"Your score is : {score}");
    }
}