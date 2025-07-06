using MathGame_Niasua.Models;

namespace MathGame_Niasua;
internal class GameEngine
{
    internal void DivisionGame(string message, DifficultyLevel difficulty)
    {
        Random random = new Random();
        PlayGame(message, difficulty, GameType.Division,
            (a, b) => a / b, random
        );
    }

    internal void MultiplicationGame(string message, DifficultyLevel difficulty)
    {
        Random random = new Random();
        PlayGame(message, difficulty, GameType.Multiplication,
            (a, b) => a * b, random
        );
    }

    internal void SubtractionGame(string message, DifficultyLevel difficulty)
    {
        Random random = new Random();
        PlayGame(message, difficulty, GameType.Subtraction,
            (a, b) => a - b, random
        );
    }

    internal void AdditionGame(string message, DifficultyLevel difficulty)
    {
        Random random = new Random();
        PlayGame(message, difficulty, GameType.Addition,
            (a, b) => a + b, random
        );
    }

    internal void PlayGame(
    string message,
    DifficultyLevel difficulty,
    GameType gameType,
    Func<int, int, int> operation,
    Random random
    )
    {

        int score = 0;
        var startTime = DateTime.Now;
        var numberQuestions = 5;
        var operationType = Helpers.SelectOperation(gameType);
        int[] operands;

        int maxNumber = difficulty switch
        {
            DifficultyLevel.Easy => 9,
            DifficultyLevel.Medium => 50,
            DifficultyLevel.Hard => 100,
            _ => 9
        };


        if (gameType == GameType.Division)
        {
            numberQuestions = difficulty switch
            {
                DifficultyLevel.Easy => 5,
                DifficultyLevel.Medium => 10,
                DifficultyLevel.Hard => 15,
                _ => 5
            };

            operands = Helpers.GetDivisionNumbers();
        }

        for (int i = 0; i < numberQuestions; i++)
        {
            operands = Helpers.GetNumbers(maxNumber, random);
            Console.Clear();
            Console.WriteLine(message);

            int firstNumber = operands[0];
            int secondNumber = operands[1];

            Console.WriteLine($"{firstNumber} {operationType} {secondNumber}");
            var result = Console.ReadLine();

            result = Helpers.ValidateResult(result);

            if (int.Parse(result) == operation(firstNumber, secondNumber))
            {
                Console.WriteLine("Your answer was correct! Type any key for the next question");
                score++;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Your anser was incorrect! Type any key for the next question");
                Console.ReadLine();
            }

            if (i == numberQuestions - 1)
            {
                Helpers.ShowFinalResults(score, startTime);
            }
        }

        Helpers.AddToHistory(score, GameType.Addition);
    }
}
