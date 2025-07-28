using System.Collections.Generic;

namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(folderPath);

            long totalSize = 0;
            while (queue.Count > 0)
            {
                string currentPath  = queue.Dequeue();

                foreach (var file in Directory.GetFiles(currentPath))
                {
                    FileInfo info = new FileInfo(file);
                    totalSize += info.Length;
                }

                foreach (var subFolder in Directory.GetDirectories(currentPath))
                {
                    queue.Enqueue(subFolder);
                }

                File.WriteAllText(outputFilePath, $"{totalSize / 1024m} KB");
            }
        }
    }
}
