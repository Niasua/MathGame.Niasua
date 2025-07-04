using MathGame_Niasua.Models;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace MathGame_Niasua;
internal class Helpers
{
    internal static List<Game> games = new()
    {
        //new Game { Date = DateTime.Now.AddDays(1), Type = GameType.Addition, Score = 5 },
        //new Game { Date = DateTime.Now.AddDays(2), Type = GameType.Multiplication, Score = 4 },
        //new Game { Date = DateTime.Now.AddDays(3), Type = GameType.Division, Score = 4 },
        //new Game { Date = DateTime.Now.AddDays(4), Type = GameType.Subtraction, Score = 3 },
        //new Game { Date = DateTime.Now.AddDays(5), Type = GameType.Addition, Score = 1 },
        //new Game { Date = DateTime.Now.AddDays(6), Type = GameType.Multiplication, Score = 2 },
        //new Game { Date = DateTime.Now.AddDays(7), Type = GameType.Division, Score = 3 },
        //new Game { Date = DateTime.Now.AddDays(8), Type = GameType.Subtraction, Score = 4 },
        //new Game { Date = DateTime.Now.AddDays(9), Type = GameType.Addition, Score = 4 },
        //new Game { Date = DateTime.Now.AddDays(10), Type = GameType.Multiplication, Score = 1 },
        //new Game { Date = DateTime.Now.AddDays(11), Type = GameType.Subtraction, Score = 0 },
        //new Game { Date = DateTime.Now.AddDays(12), Type = GameType.Division, Score = 2 },
        //new Game { Date = DateTime.Now.AddDays(13), Type = GameType.Subtraction, Score = 5 },
    };
    internal static string GetName()
    {
        Console.Write("Please type your name: ");
        string name = Console.ReadLine(); 

        while (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Name can't be empty");
            name = Console.ReadLine();
        }

        return name;
    }
    internal static int[] GetDivisionNumbers()
    {
        Random Random = new Random();
        int firstNumber = Random.Next(0, 99);
        int secondNumber = Random.Next(0, 99);

        int[] result = new int[2];

        // the division must result in an integer
        // the second number must be != 0 and greater than the first number
        while (firstNumber % secondNumber != 0 && secondNumber == 0 && secondNumber > firstNumber)
        {
            firstNumber = Random.Next(0, 99);
            secondNumber = Random.Next(0, 99);
        }

        result[0] = firstNumber;
        result[1] = secondNumber;

        return result;
    }
    internal static void PrintGames()
    {
        var gamesToPrint = games.Where(x => x.Date > new DateTime(2022, 08, 09)).OrderByDescending(x => x.Score);

        Console.Clear();
        Console.WriteLine("Games History");
        Console.WriteLine("------------------------------------------------------");
        foreach (var game in gamesToPrint)
        {
            Console.WriteLine($"{game.Date} - {game.Type}: {game.Score}");
        }
        Console.WriteLine("------------------------------------------------------\n");
        Console.WriteLine("Press any key to go back to the menu");
        Console.ReadLine();
    }
    internal static void AddToHistory(int score, GameType game)
    {
        games.Add(new Game
        {
            Date = DateTime.Now,
            Score = score,
            Type = game
        });
    }

    internal static string? ValidateResult(string result)
    {
        while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
        {
            Console.WriteLine("Your answer needs to be an integer. Try again.");
            result = Console.ReadLine();
        }
        return result;
    }

    internal static DifficultyLevel selectDifficulty()
    {
        Console.Clear();
        Console.WriteLine("Select difficulty:");
        Console.WriteLine("1. Easy");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. Hard");

        string input = Console.ReadLine();
        int selection;

        while(!int.TryParse(input, out selection) || selection < 1 || selection > 3)
        {
            Console.WriteLine("Invalid input. Please select 1, 2 or 3:");
            input = Console.ReadLine();
        }

        return selection switch
        {
            1 => DifficultyLevel.Easy,
            2 => DifficultyLevel.Medium,
            3 => DifficultyLevel.Hard
        };
    }

    internal static void ShowFinalResults(int score, DateTime startTime)
    {
        var endTime = DateTime.Now;
        var duration = endTime - startTime;
        Console.WriteLine($"Game over. Your final score is: {score}");
        Console.WriteLine($"Time taken: {(int)duration.TotalSeconds} seconds");
        Console.ReadLine();
    }
}

