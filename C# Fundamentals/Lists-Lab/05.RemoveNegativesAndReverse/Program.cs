using System.ComponentModel.Design;

namespace _05.RemoveNegativesAndReverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            /*int count = numbers.Count;

            for (int i = 0; i < count; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers.RemoveAt(i);
                    i--;
                    count--;
                }
            }*/
            numbers.RemoveAll(n => n < 0);
            if (numbers.Count > 0)
            {
            numbers.Reverse();
            Console.WriteLine(string.Join(" ", numbers));
            }
            else
            {
                Console.WriteLine("empty");
            }
  
        }
    }
}
