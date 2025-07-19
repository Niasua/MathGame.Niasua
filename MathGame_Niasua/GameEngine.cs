using MathGame_Niasua.Models;

namespace MathGame_Niasua;
internal class GameEngine
{
    internal void RandomGame(string message, DifficultyLevel difficulty, Random random)
    {
        int score = 0;
        DateTime startTime = DateTime.Now;
        for (int i = 0; i < 5; i++)
        {
            var gameTypeNumber = random.Next(0, 4);

            switch (gameTypeNumber)
            {
                case 0:
                    score += PlayGame(message, difficulty, GameType.Addition, Helpers.GetNumbers, random, 1, true
                    );
                    break;
                case 1:
                    score += PlayGame(message, difficulty, GameType.Subtraction, Helpers.GetNumbers, random, 1, true 
                    );
                    break;
                case 2:
                    score += PlayGame(message, difficulty, GameType.Multiplication, Helpers.GetNumbers, random, 1, true
                    );
                    break;
                case 3:
                    score += PlayGame(message, difficulty, GameType.Division, Helpers.GetDivisionNumbers, random, 1, true
                    );
                    break;
            }
        }

        Helpers.AddToHistory(score, GameType.Random);
        Helpers.ShowFinalResults(score, startTime);
    }

    internal int PlayGame(
    string message,
    DifficultyLevel difficulty,
    GameType gameType,
    Func<int, Random ,int[]> GetOperands,
    Random random,
    int numberQuestions, bool isRandom
    )
    {
        int score = 0;
        DateTime startTime = DateTime.Now;

        Console.WriteLine(message);

        int maxNumber = difficulty switch
        {
            DifficultyLevel.Easy => 9,
            DifficultyLevel.Medium => 50,
            DifficultyLevel.Hard => 100,
            _ => 9
        };

        switch(gameType)
        {
            case GameType.Addition:
                score += Helpers.GameLogic(numberQuestions, maxNumber, Helpers.GetNumbers, score, DateTime.Now, random, Helpers.SelectOperation(gameType), (a, b) => a + b);
                break;
            case GameType.Subtraction:
                score += Helpers.GameLogic(numberQuestions, maxNumber, Helpers.GetNumbers, score, DateTime.Now, random, Helpers.SelectOperation(gameType), (a, b) => a - b);
                break;
            case GameType.Multiplication:
                score += Helpers.GameLogic(numberQuestions, maxNumber, Helpers.GetNumbers, score, DateTime.Now, random, Helpers.SelectOperation(gameType), (a, b) => a * b);
                break;
            case GameType.Division:
                score += Helpers.GameLogic(numberQuestions, maxNumber, Helpers.GetDivisionNumbers, score, DateTime.Now, random, Helpers.SelectOperation(gameType), (a, b) => a / b);
                break;
        }

        if (!isRandom)
        {
            Helpers.AddToHistory(score, gameType);
            Helpers.ShowFinalResults(score, startTime);
        }

        return score;
    }
}
