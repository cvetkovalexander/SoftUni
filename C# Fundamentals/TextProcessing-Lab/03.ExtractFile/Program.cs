using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        //string file = Console.ReadLine();

        //string fileName
        //    = String.Empty;
        //string fileExtension
        //    = String.Empty;

        //int fileSeparator = file.LastIndexOf('\\');
        //int extensionSeparator = file.LastIndexOf('.');

        //if (fileSeparator != -1 && extensionSeparator != -1 && extensionSeparator > fileSeparator)
        //{                                   Решение 100/100
        //    fileName = file.Substring(fileSeparator + 1, extensionSeparator - fileSeparator - 1);
        //    fileExtension = file.Substring(extensionSeparator + 1);
        //}


        //if (file.Contains('\\') && file.Contains('.'))
        //{
        //    string[] filePath = file.Split('\\');
        //    string[] nameExtension = filePath[3].Split('.');
        //    fileName = nameExtension[0];                        Решение 80/100 ???
        //    fileExtension = nameExtension[1];
        //    if (nameExtension[1].Length < nameExtension[0].Length)
        //    {
        //        Console.WriteLine($"File name: {fileName}");
        //        Console.WriteLine($"File extension: {fileExtension}");
        //    }
        //}

        //List<string> filePath = Console.ReadLine()
        //    .Split('\\')
        //    .ToList();

        //string[] fileInfo = filePath[filePath.Count - 1].Split('.');

        //Console.WriteLine($"File name: {fileInfo[0]}");
        //Console.WriteLine($"File extension: {fileInfo[1]}");

        //Console.WriteLine($"File name: {fileName}");
        //Console.WriteLine($"File extension: {fileExtension}");

        string file = Console.ReadLine();

        Console.WriteLine($"File name: {Path.GetFileNameWithoutExtension(file)}");
        Console.WriteLine($"File extension: {Path.GetExtension(file).Replace(".", "")}");

    }
}
