class Program
{
    static void Main()
    {
        Dictionary<string, int> potions = new()
        {
            ["Brew of Immortality"] = 110,
            ["Essence of Resilience"] = 100,
            ["Draught of Wisdom"] = 90,
            ["Potion of Agility"] = 80,
            ["Elixir of Strength"] = 70
        };

        List<string> crafted = new();
        Stack<int> substances =
            new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

        Queue<int> crystals =
            new(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

        while (substances.Count > 0)
        {
            bool isMatched = false;
            //if (substances.Count == 0) break;

            int substance = substances.Pop();
            int crystal = crystals.Dequeue();
            crystals.Enqueue(0);

            foreach (var (potion, energy) in potions)
            {
                if (substance + crystal == energy)
                {
                    isMatched = true;
                    crafted.Add(potion);
                    if (crafted.Count == 5)
                    {
                        Console.WriteLine("Success! The alchemist has forged all potions!");
                        Output(substances, crystals, crafted);
                        return;
                    }
                    potions.Remove(potion);
                    break;
                }
            }

            if (!isMatched)
            {
                foreach (var (potion, energy) in potions.OrderByDescending(x => x.Value))
                {
                    if (substance + crystal > energy)
                    {
                        crafted.Add(potion);
                        if (crafted.Count == 5)
                        {
                            Console.WriteLine("Success! The alchemist has forged all potions!");
                            Output(substances, crystals, crafted);
                            return;
                        }

                        if (substances.Count > 0)
                        {
                            int leftover = substances.Pop();
                            substances.Push(leftover * 2);
                        }

                        potions.Remove(potion);
                        break;
                    }
                }

            }

            crystals = new Queue<int>(crystals.Select(n => n + 5));
        }

        crystals = new Queue<int>(crystals.Select(n => n - 5));
        Console.WriteLine("The alchemist failed to complete his quest.");
        Output(substances, crystals, crafted);

    }

    static void Output(Stack<int> substances, Queue<int> crystals, List<string> potions)
    {
        if (potions.Count > 0)
        {
            Console.WriteLine($"Crafted potions: {string.Join(", ", potions)}");
        }

        if (substances.Count > 0)
        {
            Console.WriteLine($"Substances: {string.Join(", ", substances)}");
        }

        if (crystals.Count > 0)
        {
            Console.WriteLine($"Crystals: {string.Join(", ", crystals)}");
        }
    }
}