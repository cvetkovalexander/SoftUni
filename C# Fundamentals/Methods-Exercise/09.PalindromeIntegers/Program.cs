
namespace _09.PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                Console.WriteLine(IsPalindrome(input));

            }
        }

        static bool IsPalindrome(string input)
        {
            string reversed = ReversedString(input);
            return reversed == input;
        }

        static string ReversedString(string input)
        {
            char[] str = input.ToCharArray();
            Array.Reverse(str);
            return new string(str);
        }
    }
}
