namespace _04.ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] stringArray = input.ToCharArray();
            Array.Reverse(stringArray);
            string reversedInput = new string(stringArray);
            Console.WriteLine(reversedInput);
        }
    }
}
