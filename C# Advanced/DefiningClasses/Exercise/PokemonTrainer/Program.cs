namespace PokemonTrainer;

public class Program
{
    static void Main(string[] args)
    {
        Trainer[] trainers = ReadData();
        Tournament(trainers);
        foreach (var trainer in trainers.OrderByDescending(p => p.Badges))
        {
            Console.WriteLine(trainer);
        }
    }

    private static void Tournament(Trainer[] trainers)
    {
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string element = input;
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(p => p.Element == element))
                    trainer.Badges++;
                else
                {
                    trainer.Pokemons.ForEach(p => p.Health -= 10);
                    trainer.Pokemons.RemoveAll(p => p.Health <= 0);
                }
            }
        }
    }

    private static Trainer[] ReadData()
    {
        Dictionary<string, Trainer> trainersByName = new();
        string input;
        while ((input = Console.ReadLine()) != "Tournament")
        {
            string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string trainerName = data[0]; string nameOfPokemon = data[1]; string element = data[2]; int health = int.Parse(data[3]);
            Pokemon pokemon = new(nameOfPokemon, element, health);
            if (!trainersByName.ContainsKey(trainerName))
            {
                Trainer trainer = new(trainerName);
                trainersByName[trainerName] = trainer;
            }
            trainersByName[trainerName].Pokemons.Add(pokemon);
        }
        return trainersByName.Values.ToArray();
    }
}
