using System.Threading;

namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (FileStream inputStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
            {
                int partOneSize = (int)(inputStream.Length / 2 + inputStream.Length % 2);

                using (FileStream partOneOutputStream = new FileStream(partOneFilePath, FileMode.Create, FileAccess.Write))
                    CopyExact(inputStream, partOneOutputStream, partOneSize);

                int partTwoSize = (int)inputStream.Length / 2;

                using (FileStream partTwoOutputStream = new FileStream(partTwoFilePath, FileMode.Create, FileAccess.Write))
                    CopyExact(inputStream, partTwoOutputStream, partTwoSize);
            }
        }

        private static void CopyExact(Stream inputStream, Stream outputStream, int count)
        {
            byte[] buffer = new byte[1024];

            int totalReadBytes = 0;
            while (totalReadBytes < count)
            {
                int readBytes = inputStream.Read(buffer, 0, Math.Min(buffer.Length, count - totalReadBytes));

                outputStream.Write(buffer, 0, readBytes);
                totalReadBytes += readBytes;
            }
        }
        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream outputStream = new FileStream(joinedFilePath, FileMode.Create, FileAccess.Write))
            {
                using (FileStream partOne = new FileStream(partOneFilePath, FileMode.Open, FileAccess.Read))
                {
                    partOne.CopyTo(outputStream);
                }

                using (FileStream partTwo = new FileStream(partTwoFilePath, FileMode.Open, FileAccess.Read))
                {
                    partTwo.CopyTo(outputStream);
                }
            }
        }
    }
}