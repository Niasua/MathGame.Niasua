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

        do
        {
            Console.Clear();
            Console.WriteLine(@$"What game would you like to play? Choose from the options below:
                
            V - View Previous Games
            A - Addition
            S - Substraction
            M - Multiplication
            D - Division
            Q - Quit the program");

            Console.WriteLine("------------------------------------------------------");

            string gameSelected = Console.ReadLine();

            switch (gameSelected.Trim().ToLower())
            {
                case "v":
                    Helpers.PrintGames();
                    break;
                case "a":
                    gameEngine.AdditionGame("Addition game selected");
                    break;
                case "s":
                    gameEngine.SubtractionGame("Subtraction game selected");
                    break;
                case "m":
                    gameEngine.MultiplicationGame("Multiplication game selected");
                    break;
                case "d":
                    gameEngine.DivisionGame("Division game selected");
                    break;
                case "q":
                    Console.WriteLine("Goodbye");
                    isGameOn = false;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        } while (isGameOn);
    }

}

