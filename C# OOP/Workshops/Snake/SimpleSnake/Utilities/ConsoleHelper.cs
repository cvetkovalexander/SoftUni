namespace SimpleSnake.Utilities;

using System;
using System.Text;
public static class ConsoleHelper
{
    public static void CustomizeConsole()
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.CursorVisible = false;
    }

    public static void Write(char symbol, int x, int y)
    {
        SetCursorPosition(x, y);
        Console.Write(symbol);
    }

    public static void Write(string text, int x, int y)
    {
        SetCursorPosition(x, y);
        Console.Write(text);
    }

    private static void SetCursorPosition(int x, int y)
    {
        Console.CursorLeft = x;
        Console.CursorTop = y;
    }
}