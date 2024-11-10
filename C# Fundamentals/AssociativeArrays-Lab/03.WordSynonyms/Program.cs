using System;
using System.Collections.Generic;

namespace _03.WordSynonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> wordsSynonyms = new();

            for (int i = 0; i < lines; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!wordsSynonyms.ContainsKey(word))
                {
                    wordsSynonyms[word] = new List<string>();   
                    wordsSynonyms[word].Add(synonym);
                }
                else
                {
                    wordsSynonyms[word].Add(synonym);
                }
            }

            foreach (var word in wordsSynonyms)
            {
                Console.WriteLine($"{word.Key} - {string.Join(", ", word.Value)}");
            }
        }
    }
}
