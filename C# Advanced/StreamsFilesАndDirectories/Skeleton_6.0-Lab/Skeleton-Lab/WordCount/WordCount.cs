namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (StreamReader wordReader = new StreamReader(wordsFilePath))
            {
                string wordLine = wordReader.ReadLine();
                string[] words = wordLine.Split(' ');
                Dictionary<string, int> wordCounts = new Dictionary<string, int>();
                using (StreamReader textReader = new StreamReader(textFilePath))
                {
                    using (StreamWriter outputWriter = new StreamWriter(outputFilePath))
                    {
                        while (!textReader.EndOfStream)
                        {
                            string line = textReader.ReadLine();
                            string[] lineArray = line.Split("-.,?!\n\r ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                            foreach (var word in words)
                            {
                                if (!wordCounts.ContainsKey(word))
                                    wordCounts[word] = 0;
                                for (int i = 0; i < lineArray.Length; i++)
                                {
                                    if (lineArray[i].ToLower() == word)
                                    {
                                        wordCounts[word]++;
                                    }
                                }
                            }
                        }

                        foreach (var (word, count) in wordCounts.OrderByDescending(x => x.Value))
                        {
                            outputWriter.WriteLine($"{word} - {count}");
                        }
                    }
                }
            }
        }
    }
}
