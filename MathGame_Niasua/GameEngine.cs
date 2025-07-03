using MathGame_Niasua.Models;

namespace MathGame_Niasua;
internal class GameEngine
{
    internal void DivisionGame(string message)
    {
        var score = 0;

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine(message);

            int[] nums = Helpers.GetDivisionNumbers();
            int firstNumber = nums[0];
            int secondNumber = nums[1];

            Console.WriteLine($"{firstNumber} / {secondNumber}");
            var result = Console.ReadLine();

            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber / secondNumber)
            {
                Console.WriteLine("Your answer was correct! Type any key for the next question");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect! Type any key for the next question");
                Console.ReadLine();
            }

            if (i == 4)
            {
                Console.WriteLine($"Game over. Your final score is {score}");
                Console.ReadLine();
            }
        }

        Helpers.AddToHistory(score, GameType.Division);
    }
    internal void MultiplicationGame(string message)
    {
        Random random = new Random();
        var score = 0;

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine(message);
            int firstNumber = random.Next(1, 9);
            int secondNumber = random.Next(1, 9);

            Console.WriteLine($"{firstNumber} * {secondNumber}");
            var result = Console.ReadLine();

            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber * secondNumber)
            {
                Console.WriteLine("Your answer was correct! Type any key for the next question");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect! Type any key for the next question");
                Console.ReadLine();
            }

            if (i == 4)
            {
                Console.WriteLine($"Game over. Your final score is {score}");
                Console.ReadLine();
            }
        }

        Helpers.AddToHistory(score, GameType.Multiplication);
    }
    internal void SubtractionGame(string message)
    {
        Random random = new Random();
        var score = 0;

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine(message);
            int firstNumber = random.Next(1, 9);
            int secondNumber = random.Next(1, 9);

            Console.WriteLine($"{firstNumber} - {secondNumber}");
            var result = Console.ReadLine();

            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == firstNumber - secondNumber)
            {
                Console.WriteLine("Your answer was correct! Type any key for the next question");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect! Type any key for the next question");
                Console.ReadLine();
            }

            if (i == 4)
            {
                Console.WriteLine($"Game over. Your final score is {score}");
                Console.ReadLine();
            }
        }

        Helpers.AddToHistory(score, GameType.Subtraction);
    }
    internal void AdditionGame(string message)
    {
        Random random = new Random();
        var score = 0;

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine(message);
            int firstNumber = random.Next(1, 9);
            int secondNumber = random.Next(1, 9);

            Console.WriteLine($"{firstNumber} + {secondNumber}");
            var result = Console.ReadLine();

            result = Helpers.ValidateResult(result);


            if (int.Parse(result) == firstNumber + secondNumber)
            {
                Console.WriteLine("Your answer was correct! Type any key for the next question");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your answer was incorrect! Type any key for the next question");
                Console.ReadLine();
            }

            if (i == 4)
            {
                Console.WriteLine($"Game over. Your final score is {score}");
                Console.ReadLine();
            }
        }

        Helpers.AddToHistory(score, GameType.Addition);
    }
}
