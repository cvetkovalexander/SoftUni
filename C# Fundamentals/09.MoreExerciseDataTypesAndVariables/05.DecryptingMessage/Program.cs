namespace _05.DecryptingMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[] output = new char[n];

            for (int i = 0; i < n; i++)
            {
                char input = char.Parse(Console.ReadLine());

                int shifted = (int)input + key;

                output[i] = (char)shifted;
            }
            Console.WriteLine(string.Join("", output));
        }
    }
}