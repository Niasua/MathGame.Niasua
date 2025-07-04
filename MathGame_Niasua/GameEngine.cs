using MathGame_Niasua.Models;

namespace MathGame_Niasua;
internal class GameEngine
{
    internal void DivisionGame(string message, DifficultyLevel difficulty)
    {
        var score = 0;

        int numberQuestions = difficulty switch
        {
            DifficultyLevel.Easy => 5,
            DifficultyLevel.Medium => 10,
            DifficultyLevel.Hard => 15
        };

        for (int i = 0; i < numberQuestions; i++)
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

            if (i == numberQuestions - 1)
            {
                Console.WriteLine($"Game over. Your final score is {score}");
                Console.ReadLine();
            }
        }

        Helpers.AddToHistory(score, GameType.Division);
    }
    internal void MultiplicationGame(string message, DifficultyLevel difficulty)
    {
        Random random = new Random();
        var score = 0;

        int maxNumber = difficulty switch
        {
            DifficultyLevel.Easy => 9,
            DifficultyLevel.Medium => 50,
            DifficultyLevel.Hard => 100,
            _ => 9
        };

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine(message);
            int firstNumber = random.Next(1, maxNumber + 1);
            int secondNumber = random.Next(1, maxNumber + 1);

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
    internal void SubtractionGame(string message, DifficultyLevel difficulty)
    {
        Random random = new Random();
        var score = 0;

        int maxNumber = difficulty switch
        {
            DifficultyLevel.Easy => 9,
            DifficultyLevel.Medium => 50,
            DifficultyLevel.Hard => 100,
            _ => 9
        };

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine(message);
            int firstNumber = random.Next(1, maxNumber + 1);
            int secondNumber = random.Next(1, maxNumber + 1);

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
    internal void AdditionGame(string message, DifficultyLevel difficulty)
    {
        Random random = new Random();
        var score = 0;

        int maxNumber = difficulty switch
        {
            DifficultyLevel.Easy => 9,
            DifficultyLevel.Medium => 50,
            DifficultyLevel.Hard => 100,
            _ => 9
        };

        for (int i = 0; i < 5; i++)
        {
            Console.Clear();
            Console.WriteLine(message);
            int firstNumber = random.Next(1, maxNumber + 1);
            int secondNumber = random.Next(1, maxNumber + 1);

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
