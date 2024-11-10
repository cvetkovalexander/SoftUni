namespace _00.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new() {1, 2, 3, 4};
            list.Add(69);
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
