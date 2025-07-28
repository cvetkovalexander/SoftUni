namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamReader firstInputReader = new StreamReader(firstInputFilePath))
            {
                using (StreamReader secondInputReader = new StreamReader(secondInputFilePath))
                {
                    using (StreamWriter outputWriter = new StreamWriter(outputFilePath))
                    {
                        while (!firstInputReader.EndOfStream || !secondInputReader.EndOfStream)
                        {
                            if (!firstInputReader.EndOfStream)
                                outputWriter.WriteLine(firstInputReader.ReadLine());

                            if (!secondInputReader.EndOfStream)
                                outputWriter.WriteLine(secondInputReader.ReadLine());
                        }
                    }
                }
            }
        }
    }
}
