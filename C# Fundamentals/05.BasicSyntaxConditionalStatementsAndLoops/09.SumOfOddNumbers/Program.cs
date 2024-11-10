

using System.ComponentModel.DataAnnotations;

class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <= num; i ++)
        {
            
            
                Console.WriteLine(2 * i - 1);
                sum += 2 * i - 1;
            
            
        }
        Console.WriteLine($"Sum: {sum}");
        }
    }

