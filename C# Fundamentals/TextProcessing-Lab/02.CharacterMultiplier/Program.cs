using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.NetworkInformation;
using System.Net.Sockets;

class Program
{
    static void Main()
    {
        //int sum = 0;
        //string[] input = Console.ReadLine().Split();

        //char[] char1 = input[0].ToCharArray();
        //char[] char2 = input[1].ToCharArray();

        //if (char1.Length > char2.Length)
        //{
        //    sum = CalculateSum(char2, sum, char1);
        //}
        //else if (char1.Length < char2.Length)
        //{
        //    sum = CalculateSum(char1, sum, char2);
        //}
        //else
        //{
        //    sum = CalculateSum(char2, sum, char1);
        //}

        //Console.WriteLine(sum);

        string[] input = Console.ReadLine().Split();

        Console.WriteLine(Sum(input[0], input[1]));
    }

    static int Sum(string first, string second)
    {
        int sum = 0;

        int length = Math.Max(first.Length, second.Length);

        for (int i = 0; i < length; i++)
        {
            if (i < first.Length && i < second.Length)
            {
                sum += first[i] * second[i];
            }
            else if (i < first.Length)
            {
                sum += first[i];
            }
            else if (i < second.Length)
            {
                sum += second[i];
            }
        }

        return sum;
    }

    //private static int CalculateSum(char[] char2, int sum, char[] char1)
    //{
    //    if (char1.Length != char2.Length)
    //    {
    //        for (int i = 0; i < char2.Length; i++)
    //        {
    //            sum += (int)char1[i] * (int)char2[i];
    //        }

    //        for (int i = char1.Length - 1; i >= char2.Length; i--)
    //        {
    //            sum += (int)char1[i];
    //        }
    //    }
    //    else
    //    {
    //        for (int i = 0; i < char1.Length; i++)
    //        {
    //            sum += (int)char1[i] * (int)char2[i];
    //        }
    //    }

    //    return sum;
    //}
}