using MathGame_Niasua.Models;
using static System.Formats.Asn1.AsnWriter;

namespace MathGame_Niasua;
internal class GameEngine
{
    internal void DivisionGame(string message, DifficultyLevel difficulty)
    {
        int score = 0;
        DateTime startTime = DateTime.Now;
        Random random = new Random();
        Console.WriteLine(message);
        score += PlayGame(difficulty, GameType.Division, Helpers.GetDivisionNumbers, random, 5
        );
        Helpers.AddToHistory(score, GameType.Division);
        Helpers.ShowFinalResults(score, startTime);
    }

    internal void MultiplicationGame(string message, DifficultyLevel difficulty)
    {
        int score = 0;
        DateTime startTime = DateTime.Now;
        Random random = new Random();
        Console.WriteLine(message);
        score += PlayGame(difficulty, GameType.Multiplication, Helpers.GetNumbers, random, 5
        );
        Helpers.AddToHistory(score, GameType.Multiplication);
        Helpers.ShowFinalResults(score, startTime);
    }

    internal void SubtractionGame(string message, DifficultyLevel difficulty)
    {
        int score = 0;
        DateTime startTime = DateTime.Now;
        Random random = new Random();
        Console.WriteLine(message);
        score += PlayGame(difficulty, GameType.Subtraction, Helpers.GetNumbers, random, 5
        );
        Helpers.AddToHistory(score, GameType.Subtraction);
        Helpers.ShowFinalResults(score, startTime);
    }

    internal void AdditionGame(string message, DifficultyLevel difficulty)
    {
        int score = 0;
        DateTime startTime = DateTime.Now;
        Random random = new Random();
        Console.WriteLine(message);
        score += PlayGame(difficulty, GameType.Addition, Helpers.GetNumbers, random, 5
        );
        Helpers.AddToHistory(score, GameType.Addition);
        Helpers.ShowFinalResults(score, startTime);
    }

    internal void RandomGame(string message, DifficultyLevel difficulty)
    {
        int score = 0;
        DateTime startTime = DateTime.Now;
        Random random = new Random();
        for (int i = 0; i < 5; i++)
        {
            var gameTypeNumber = random.Next(0, 4);

            switch (gameTypeNumber)
            {
                case 0:
                    Console.WriteLine(message);
                    score += PlayGame(difficulty, GameType.Addition, Helpers.GetNumbers, random, 1
                    );
                    break;
                case 1:
                    Console.WriteLine(message);
                    score += PlayGame(difficulty, GameType.Subtraction, Helpers.GetNumbers, random, 1
                    );
                    break;
                case 2:
                    Console.WriteLine(message);
                    score += PlayGame(difficulty, GameType.Multiplication, Helpers.GetNumbers, random, 1
                    );
                    break;
                case 3:
                    Console.WriteLine(message);
                    score += PlayGame(difficulty, GameType.Division, Helpers.GetDivisionNumbers, random, 1
                    );
                    break;
            }
        }

        Helpers.AddToHistory(score, GameType.Random);
        Helpers.ShowFinalResults(score, startTime);
    }

    internal int PlayGame(
    DifficultyLevel difficulty,
    GameType gameType,
    Func<int, Random ,int[]> GetOperands,
    Random random,
    int numberQuestions
    )
    {
        int score = 0;
        int maxNumber = difficulty switch
        {
            DifficultyLevel.Easy => 9,
            DifficultyLevel.Medium => 50,
            DifficultyLevel.Hard => 100,
            _ => 9
        };

        int[] operands = GetOperands(maxNumber, random);

        switch(gameType)
        {
            case GameType.Addition:
                score += Helpers.GameLogic(numberQuestions, maxNumber, operands, score, DateTime.Now, random, Helpers.SelectOperation(gameType), (a, b) => a + b);
                break;
            case GameType.Subtraction:
                score += Helpers.GameLogic(numberQuestions, maxNumber, operands, score, DateTime.Now, random, Helpers.SelectOperation(gameType), (a, b) => a - b);
                break;
            case GameType.Multiplication:
                score += Helpers.GameLogic(numberQuestions, maxNumber, operands, score, DateTime.Now, random, Helpers.SelectOperation(gameType), (a, b) => a * b);
                break;
            case GameType.Division:
                score += Helpers.GameLogic(numberQuestions, maxNumber, operands, score, DateTime.Now, random, Helpers.SelectOperation(gameType), (a, b) => a / b);
                break;
        }

        return score;
    }
}
