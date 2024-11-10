namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<int> wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int maxCapacity = int.Parse(Console.ReadLine());

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArgs = command.Split();
                if (commandArgs[0] == "Add")
                {
                    wagons.Add(int.Parse(commandArgs[1]));
                }
                else
                {
                    int passengers = int.Parse(commandArgs[0]);
                        for (int i = 0; i < wagons.Count; i++)
                        {
                            if (wagons[i] + passengers <= maxCapacity)
                                    {
                            wagons[i] += passengers;
                            break;
                                    }
                        }   
                }
            }
            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
