﻿namespace MathGame_Niasua.Models;
internal class Game
{
    public DateTime Date { get; set; }
    public int Score { get; set; }
    public GameType Type { get; set; }

}

internal enum GameType
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
    Random
}

internal enum DifficultyLevel
{
    Easy,
    Medium,
    Hard
}
