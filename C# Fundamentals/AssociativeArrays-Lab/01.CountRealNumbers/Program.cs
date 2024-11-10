namespace _01.CountRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split();

            SortedDictionary<string, int> dictionary = new();

            foreach (string number in numbers)
            {
                if (dictionary.ContainsKey(number))
                {
                    dictionary[number]++;
                }
                else
                {
                    dictionary.Add(number, 1);
                }
            }

            foreach (var number in dictionary)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
        
            
    }
}
