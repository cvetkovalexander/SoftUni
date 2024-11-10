namespace _04.ListOfProducts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<string> products = new();

            while (lines > 0)
            {
                string product = Console.ReadLine();
                products.Add(product);
                lines--;
            }
            products.Sort();
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{products[i]}");
            }
        }
    }
}
