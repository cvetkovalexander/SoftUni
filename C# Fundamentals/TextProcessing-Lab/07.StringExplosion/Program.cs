using System;
using System.Text;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        int explosion = 0;

        StringBuilder result = new();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '>') 
            {
                explosion += int.Parse(input[i + 1].ToString());
                result.Append(input[i]);
            }
            else if (explosion == 0)
            {
                result.Append(input[i]);
            }
            else
            {
                explosion--;
            }
        }

        Console.WriteLine(result);
    }
}
