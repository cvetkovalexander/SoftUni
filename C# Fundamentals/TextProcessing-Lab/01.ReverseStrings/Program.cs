using System;

class Program
{
    static void Main()
    {
        string input;
        while ((input = Console.ReadLine()) != "end")
        {
            string reversed = "";

            //for (int i = input.Length; i > 0; i--)
            //{
            //    reversed += input[i - 1];
            //}


            char[] inputToChar = input.ToCharArray();

            for (int i = inputToChar.Length - 1; i >= 0; i--)
            {
                reversed += inputToChar[i];
            }
            
            Console.WriteLine($"{input} = {reversed}");
        }
    }
}