
namespace _09.PokemonDon_tGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int removedSum = 0;

            while (pokemons.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                int removedNumber = 0;
                if (index < 0)
                {
                    removedNumber = pokemons[0];
                    pokemons[0] = pokemons[pokemons.Count - 1];
                    
                }
                else if (index > pokemons.Count - 1)
                {
                    removedNumber = pokemons[pokemons.Count - 1];
                    pokemons[pokemons.Count - 1] = pokemons[0];
                }
                else
                {
                    removedNumber = pokemons[index];
                    pokemons.RemoveAt(index);
                    
                }
                removedSum += removedNumber;

                for (int i = 0; i < pokemons.Count; i++)
                {
                    if (pokemons[i] <= removedNumber)
                    {
                        pokemons[i] += removedNumber;
                    }
                    else if (pokemons[i] > removedNumber)
                    {
                       pokemons[i] -= removedNumber;
                    }
                }
            }
            Console.WriteLine(removedSum);
        }

         
    }
}
