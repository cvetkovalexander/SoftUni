using System;
using System.Linq;

namespace _04.WordFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split()
                .Where(word => word.Length % 2 == 0)
                .ToArray();

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }

            //string[] words = Console.ReadLine()
            //    .Split();
            //List<string> evenLengthWords = new();

            //foreach (var word in words)
            //{
            //    if (word.Length % 2 == 0)   
            //    {
            //        evenLengthWords.Add(word);
            //    }
            //}

            //foreach (var word in evenLengthWords)
            //{
            //    Console.WriteLine(word);
            //}
        }
    }
}
