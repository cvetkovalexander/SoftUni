using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Queue<string> songs = new(Console.ReadLine().Split(", "));

        while (songs.Count > 0)
        {
            string[] tokens = Console.ReadLine().Split();
            switch (tokens[0])
            {
                case "Play":
                    songs.Dequeue();
                    break;
                case "Add":
                    List<string> songParts = new();
                    for (int i = 1; i < tokens.Length; i++)
                    {
                        songParts.Add(tokens[i]);
                    }
                    string song = string.Join(" ", songParts);
                    if (songs.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(song);
                    }
                    break;
                case "Show":
                    Console.WriteLine(string.Join(", ", songs));
                    break;
            }
        }

        Console.WriteLine("No more songs!");
    }
}