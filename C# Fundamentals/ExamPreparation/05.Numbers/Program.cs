namespace _05.Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> output = new();

            double sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }
            double averageSum = sum / numbers.Count;

            for (int i = 0;i < numbers.Count; i++)
            {
                if (numbers[i] > averageSum)
                {
                    output.Add(numbers[i]);           
                }
            }
            output = output.OrderByDescending(x => x).ToList();
            int[] finaloutput = new int[5];
            if (output.Count > 5)
            {
                for (int i = 0;i< finaloutput.Length; i++)
                {
                    finaloutput[i] += output[i];
                }
                if (finaloutput.Length > 0)
                {
                    Console.WriteLine(string.Join(" ", finaloutput));
                }
                else
                {
                    Console.WriteLine("No");
                }
            }
            else
            {
                if (output.Count > 0)
                {
                Console.WriteLine(string.Join(" ", output));
                }
                else
                {
                    Console.WriteLine("No");
                }
            }
           
        }
    }
}
