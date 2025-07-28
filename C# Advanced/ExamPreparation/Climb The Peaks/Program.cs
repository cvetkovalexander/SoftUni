namespace Climb_The_Peaks;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> peaks = new Dictionary<string, int>
        {
            ["Vihren"] = 80,
            ["Kutelo"] = 90,
            ["Banski Suhodol"] = 100,
            ["Polezhan"] = 60,
            ["Kamenitza"] = 70
        };
        Stack<int> foodSupplies = new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        Queue<int> staminaQuantity = new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

        List<string> conquered = new();

        foreach (var (peak, difficulty) in peaks)
        {
            if (foodSupplies.Count == 0 || staminaQuantity.Count == 0)
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
                if (conquered.Count > 0)
                {
                    Console.WriteLine("Conquered peaks:");
                    foreach (string peaK in conquered)
                        Console.WriteLine(peaK);
                }
                return;
            }
            int food = foodSupplies.Pop();
            int stamina = staminaQuantity.Dequeue();

            if ((food + stamina) >= difficulty)
            {
                conquered.Add(peak);
            }
            else
            {
                if (ExtractSuppliesUntilPeak(foodSupplies, staminaQuantity, conquered, difficulty, peak)) return;
            }
        }

        Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
        Console.WriteLine("Conquered peaks:");
        foreach (string peak in conquered)
            Console.WriteLine(peak);
    }

    static bool ExtractSuppliesUntilPeak(Stack<int> foodSupplies, Queue<int> staminaQuantity, List<string> conquered, int difficulty,
        string peak)
    {
        int food;
        int stamina;
        while (true)
        {
            food = foodSupplies.Pop();
            stamina = staminaQuantity.Dequeue();
            if (foodSupplies.Count == 0 || stamina == 0)
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
                if (conquered.Count > 0)
                {
                    Console.WriteLine("Conquered peaks:");
                    foreach (string peaK in conquered)
                        Console.WriteLine(peaK);
                }
                return true;
            }
            if (food + stamina >= difficulty)
            {
                conquered.Add(peak);
                break;
            }
        }

        return false;
    }
}