namespace MathGame_Niasua;
internal class Menu
{
    GameEngine gameEngine = new();
    internal void ShowMenu(string name, DateTime date)
    {
        Console.Clear();
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine($"Hello {name}. It's {date}. This is your math's game. ");
        Console.WriteLine("Press any key to show menu");
        Console.ReadLine();
        Console.WriteLine("\n");

        bool isGameOn = true;

        Random random = new Random();

        do
        {
            Console.Clear();
            Console.WriteLine(@$"What game would you like to play? Choose from the options below:
                
            V - View Previous Games
            A - Addition
            S - Substraction
            M - Multiplication
            D - Division
            R - Random Game
            Q - Quit the program");

            Console.WriteLine("------------------------------------------------------");

            string gameSelected = Console.ReadLine();

            switch (gameSelected.Trim().ToLower())
            {
                case "v":
                    Helpers.PrintGames();
                    break;
                case "a":
                    gameEngine.PlayGame("Addition game selected", Helpers.SelectDifficulty(), Models.GameType.Addition, Helpers.GetNumbers, random, 5, false);
                    break;
                case "s":
                    gameEngine.PlayGame("Subtraction game selected", Helpers.SelectDifficulty(), Models.GameType.Subtraction, Helpers.GetNumbers, random, 5, false);
                    break;
                case "m":
                    gameEngine.PlayGame("Multiplication game selected", Helpers.SelectDifficulty(), Models.GameType.Multiplication, Helpers.GetNumbers, random, 5, false);
                    break;
                case "d":
                    gameEngine.PlayGame("Division game selected", Helpers.SelectDifficulty(), Models.GameType.Division, Helpers.GetDivisionNumbers, random, 5, false);
                    break;
                case "q":
                    Console.WriteLine("Goodbye");
                    isGameOn = false;
                    break;
                case "r":
                    gameEngine.RandomGame("Random game selected", Helpers.SelectDifficulty(), random);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        } while (isGameOn);
    }

}

