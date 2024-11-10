namespace _02.ShootForTheWin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string input;
            int count = 0;
            while ((input = Console.ReadLine()) != "End")
            {
                int index = int.Parse(input);
                if (index < 0 || index >= targets.Length)
                {
                    continue;
                }
                int currentTarget = targets[index];
                if (targets[index] != -1)
                {
                    targets[index] = -1;
                    count++;
                }
                for (int i = 0; i < targets.Length; i++)
                {
                    if (targets[i] != -1)
                    {
                        if (targets[i] <= currentTarget)
                        {
                            targets[i] += currentTarget;
                        }
                        else
                        {
                            targets[i] -= currentTarget;
                        }
                    }
                }                  
            }
            Console.Write($"Shot targets: {count} -> ");
            for (int i = 0;i < targets.Length; i++)
            {
                Console.Write(targets[i] + " ");
            }
        }
    }
}
