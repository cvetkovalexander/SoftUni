using System;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        decimal totalSum = 0;

        foreach (string str in input)
        {
            char letterBefore = str[0];
            char letterAfter = str[str.Length - 1];
            int position;
            int num = int.Parse(str.Substring(1, str.Length - 2));
            decimal result = 0;

            if (char.IsUpper(letterBefore))
            {
                position = (int)letterBefore - 'A' + 1;
                result = num / (decimal)position;
            }
            else if (char.IsLower(letterBefore))
            {
                position = (int)letterBefore - 'a' + 1;
                result = num * position;
            }

            if (char.IsUpper(letterAfter))
            {
                position = (int)letterAfter - 'A' + 1;
                result -= position;
            }
            else if (char.IsLower(letterAfter))
            {
                position = (int)letterAfter - 'a' + 1;
                result += position;
            }

            totalSum += result;
        }

        Console.WriteLine($"{totalSum:F2}");
    }
}
