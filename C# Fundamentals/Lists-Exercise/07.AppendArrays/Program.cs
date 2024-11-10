namespace _07.AppendArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arrays = Console.ReadLine().Split('|');
            List<string> symbols = ExtractSymbols(arrays);
            Console.WriteLine(string.Join(" "   , symbols));
        }

        static List<string> ExtractSymbols(string[] arrays)
        {
            List<string> result = new List<string>();

            for (int i = arrays.Length - 1; i >= 0; i--)
            {
                string[] array = arrays[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                result.AddRange(array);
            }
            return result;
        }
    }
}
