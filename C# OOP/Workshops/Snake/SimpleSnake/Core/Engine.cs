using System;
using System.Collections.Generic;
using System.Threading;
using SimpleSnake.GameObjects;
using SimpleSnake.Utilities;

namespace SimpleSnake.Core;

public class Engine
{
    private static readonly string _trimBuffer = new string(' ', 10);

    private static readonly Dictionary<ConsoleKey, Position> _movementDirections = new()
    {
        [ConsoleKey.UpArrow] = new(0, -1),
        [ConsoleKey.RightArrow] = new(1, 0),
        [ConsoleKey.DownArrow] = new(0, 1),
        [ConsoleKey.LeftArrow] = new(-1, 0)
    };

    private static readonly Func<Food>[] _foodFactories =
    {
        () => new Food('#', 5),
        () => new Food('@', 10),
        () => new Food('$', 15),
        () => new Food('*', 20)
    };

    private static readonly string[] _gameOverMessages = 
    {
        "Game over!",
        "Do you want to try again?", 
        "-> Press Enter for \"Yes\"",
        "-> Press Escape for \"No\""
    };

    private const char FieldBorderSymbol = '\u25A0';
    private const char SnakeSymbol = '\u25CF';

    public void Play(Field field)
    {
        bool continueExecution;
        do
        {
            continueExecution = PlayInternally(field);
        }
        while (continueExecution);

        PrintFinalMessage(field);
    }

    private static bool PlayInternally(Field field)
    {
        const int foodCount = 10;

        RenderField(field);
        Snake snake = SetUpSnake();

        Dictionary<Position, Food> foodMap = new();
        PrepareFood(foodCount, foodMap, snake, field);

        int score = 0;
        float snakeSpeed = 100;
        PrintData(score, field, snake);

        bool? reset = null;
        while (!reset.HasValue)
        {
            ExecuteUserInput(snake);

            if (!Move(field, snake))
            {
                reset = ShouldReset(field);
                break;
            }

            if (foodMap.TryGetValue(snake.Head, out Food food))
            {
                score += food.Points;
                PrintData(score, field, snake);

                foodMap.Remove(snake.Head);
                PrepareFood(foodCount, foodMap, snake, field);
            }
            else
            {
                Position formerTailPosition = snake.Shorten();
                ConsoleHelper.Write(' ', formerTailPosition.X, formerTailPosition.Y);
            }

            Thread.Sleep((int)Math.Ceiling(snakeSpeed));
            if (snakeSpeed > 19) snakeSpeed -= 0.1f;
        }

        return reset.Value;
    }

    private static bool ShouldReset(Field field)
    {
        for (int i = 0; i < _gameOverMessages.Length; i++)
            ConsoleHelper.Write(_gameOverMessages[i], field.Width + 5, field.Height - _gameOverMessages.Length + i);

        bool? tryAgain = null;
        while (!tryAgain.HasValue)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Enter) tryAgain = true;
            else if (keyInfo.Key == ConsoleKey.Escape) tryAgain = false;
        }

        for (int i = 0; i < _gameOverMessages.Length; i++)
            ConsoleHelper.Write(new string(' ', _gameOverMessages[i].Length), field.Width + 5, field.Height - _gameOverMessages.Length + i);

        return tryAgain.Value;
    }

    private static void PrepareFood(int n, Dictionary<Position, Food> foodMap, Snake snake, Field field)
    {
        while (foodMap.Count < n)
        {
            int randomX = 1 + Random.Shared.Next(field.Width);
            int randomY = 1 + Random.Shared.Next(field.Height);

            Position randomPosition = new(randomX, randomY);
            if (foodMap.ContainsKey(randomPosition) || snake.IsLayingOn(randomPosition)) continue;

            int randomFactoryIndex = Random.Shared.Next(_foodFactories.Length);
            Func<Food> randomFactory = _foodFactories[randomFactoryIndex];
            Food food = randomFactory();

            foodMap[randomPosition] = food;
            ConsoleHelper.Write(food.Symbol, randomPosition.X, randomPosition.Y);
        }
    }

    private static void ExecuteUserInput(Snake snake)
    {
        if (!Console.KeyAvailable) return;

        ConsoleKeyInfo keyInfo = Console.ReadKey();
        ConsoleKey keystroke = keyInfo.Key;
        if (!_movementDirections.TryGetValue(keystroke, out Position newMovementDirection)) return;

        if (newMovementDirection != -1 * snake.MovementDirection)
            snake.MovementDirection = newMovementDirection;
    }

    private static bool Move(Field field, Snake snake)
    {
        if(!snake.Expand()) return false;

        if (snake.Head.X < 1 || snake.Head.X > field.Width || snake.Head.Y < 1 ||
            snake.Head.Y > field.Height)
            return false;

        ConsoleHelper.Write(SnakeSymbol, snake.Head.X, snake.Head.Y);
        return true;
    }

    private static Snake SetUpSnake()
    {
        Snake snake = new(new Position(1, 1), _movementDirections[ConsoleKey.RightArrow]);
        ConsoleHelper.Write(SnakeSymbol, snake.Head.X, snake.Head.Y);

        for (nint i = 1; i < 5; i++)
        {
            snake.Expand();
            ConsoleHelper.Write(SnakeSymbol, snake.Head.X, snake.Head.Y);
        }

        return snake;
    }

    private static void RenderField(Field field)
    {
        string borderRow = new string(FieldBorderSymbol, field.Width + 2);
        string middleRow = $"{FieldBorderSymbol}{new string(' ', field.Width)}{FieldBorderSymbol}";
        ConsoleHelper.Write(borderRow, 0, 0);

        for (int i = 0; i < field.Height; i++)
            ConsoleHelper.Write(middleRow, 0, i + 1);

        ConsoleHelper.Write(borderRow, 0, field.Height + 1);
    }

    private static void PrintData(int score, Field field, Snake snake)
    {
        ConsoleHelper.Write($"Score: {score}{_trimBuffer}", field.Width + 5, field.Height - 15);
        ConsoleHelper.Write($"Snake length: {snake.Length}{_trimBuffer}", field.Width + 5, field.Height - 16);
    }

    private static void PrintFinalMessage(Field field)
    {
        ConsoleHelper.Write("Thanks for playing!", 0, field.Height + 3);
        ConsoleHelper.Write(string.Empty, 0, field.Height + 4);
    }
}