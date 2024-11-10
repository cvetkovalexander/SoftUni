
namespace _02.VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(VowelsCount(input));
        }

        static int VowelsCount(string input)
        {
            int count = 0;
            input = input.ToLower();
            foreach (var symbol in input)
            {
                if (symbol == 'e' || symbol == 'o' || symbol == 'a' || symbol == 'i' || symbol == 'u')
                {
                    count++;
                }
            }
            return count;
        }
    }
}
