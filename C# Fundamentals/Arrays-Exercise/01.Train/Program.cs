namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfWagons = int.Parse(Console.ReadLine());
            int total = 0;
            int[] wagons = new int[numOfWagons];

            for (int i = 0; i < numOfWagons; i++)
            {
                int passengers = int.Parse(Console.ReadLine());
                wagons[i] = passengers;
                total += passengers;
            }
            Console.WriteLine(string.Join(" ", wagons));
            Console.WriteLine(total);

        }
    }
}
