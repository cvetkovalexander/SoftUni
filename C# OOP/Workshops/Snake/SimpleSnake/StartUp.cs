using System;
using SimpleSnake.Core;
using SimpleSnake.GameObjects;

namespace SimpleSnake;

using Utilities;

public class StartUp
{
    public static void Main()
    {
        ConsoleHelper.CustomizeConsole();
        Field field = new(70, 25);
        Engine engine = new();
        engine.Play(field);
    }
}