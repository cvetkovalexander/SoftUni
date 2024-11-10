/*int divisor1 = 2;
int divisor2 = 3;
int divisor3 = 6;
int divisor4 = 7;
int divisor5 = 10;*/

using static System.Runtime.InteropServices.JavaScript.JSType;
class Program
{
    static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            if (input % 10 == 0)
            Console.WriteLine("The number is divisible by 10");
            else if (input % 7 == 0)
            Console.WriteLine("The number is divisible by 7");
            else if (input % 6 == 0)
            Console.WriteLine("The number is divisible by 6");
            else if (input % 3 == 0)
            Console.WriteLine("The number is divisible by 3");
            else if (input % 2 == 0)
            Console.WriteLine("The number is divisible by 2");
            else Console.WriteLine("Not divisible");





    }
    }

