namespace _02.ShoppingList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            List<int> lift = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < lift.Count; i++)
            {               
                int max = 4 - lift[i];
                int peopleForLift = max;
                if (people < max)
                {
                    lift[i] += people;
                    people = 0;
                }
                else
                {
                    lift[i] += peopleForLift;
                    people -= peopleForLift;
                }
                
            }
            if (people == 0)
            {
                int sumLift = lift.Sum();
                if (sumLift < lift.Count * 4)
                {
                    Console.WriteLine("The lift has empty spots!");
                }
                Console.WriteLine(string.Join(" ", lift));
            }
            
            if (people > 0)
            {
                Console.WriteLine($"There isn't enough space! {people} people in a queue!");
                Console.WriteLine(string.Join(" ", lift));
            }

        }
    }
}
