
namespace _06.MiddleCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            MiddleCharacter(input);
        }

        private static void MiddleCharacter(string? input)
        {
            if (input.Length % 2 == 0)
            {
                Console.WriteLine(input.Substring((input.Length / 2) - 1, 2));
            }
            else
            {
                Console.WriteLine(input[input.Length / 2]);
            }
        }
    }
}
