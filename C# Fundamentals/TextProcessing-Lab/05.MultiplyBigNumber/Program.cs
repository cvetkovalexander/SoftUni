using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        string bigNumber = Console.ReadLine();
        string multiplier = Console.ReadLine();

        string result = Multiply(bigNumber, multiplier);
        Console.WriteLine(result);
    }

    static string Multiply(string number, string multiplyNum)
    {
        if (number == "0" || multiplyNum == "0")
        {
            return "0";
        }
        int carry = 0;
        int multiplier = int.Parse(multiplyNum);

        char[] charsResult = new char[number.Length + 1];

        for (int i = number.Length - 1; i >= 0; i--)
        {
            int digit = int.Parse(number[i].ToString());
            int product = digit * multiplier + carry;

            charsResult[i + 1] = (char)(product % 10 + '0');
            carry = product / 10;
        }

        if (carry > 0)
        {
            charsResult[0] = (char)(carry + '0');
        }

        return new string(charsResult).Trim();
    }
}