namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')       // Split by spaces
                .Select(int.Parse) // Convert each to an integer
                .ToList();
        }
    }
}
