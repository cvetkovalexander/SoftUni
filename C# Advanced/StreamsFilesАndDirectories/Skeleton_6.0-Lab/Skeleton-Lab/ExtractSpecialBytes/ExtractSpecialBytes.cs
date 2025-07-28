using System.Collections.Generic;

namespace ExtractSpecialBytes
{
    using System;
    using System.IO;
    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            HashSet<byte> specialBytes = new HashSet<byte>();
            using (StreamReader bytesReader = new StreamReader(bytesFilePath))
            {
                while (!bytesReader.EndOfStream)
                {
                    byte currentByte = byte.Parse(bytesReader.ReadLine());
                    specialBytes.Add(currentByte);
                }
            }

            using (FileStream inputStream = new FileStream(binaryFilePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[1024];

                    int readBytes;
                    while ((readBytes = inputStream.Read(buffer)) != 0)
                    {
                        int specialByteCount = 0;
                        for (int i = 0; i < readBytes; i++)
                        {
                            if (specialBytes.Contains(buffer[i]))
                                buffer[specialByteCount++] = buffer[i];
                        }

                        outputStream.Write(buffer, 0, specialByteCount);
                    }
                }
            }
        }
    }
}
