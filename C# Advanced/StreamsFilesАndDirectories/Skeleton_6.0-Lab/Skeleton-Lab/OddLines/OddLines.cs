namespace OddLines;
using System.IO;
	
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader inputStreamReader = new StreamReader(inputFilePath))
            {
                using (StreamWriter outputStreamWriter = new StreamWriter(outputFilePath))
                {
                    int rowNum = 0;
                    while (!inputStreamReader.EndOfStream)
                    {
                        string line = inputStreamReader.ReadLine();
                        if (rowNum++ % 2 != 0) outputStreamWriter.WriteLine(line);
                    }
                }
            }
        }
    }
