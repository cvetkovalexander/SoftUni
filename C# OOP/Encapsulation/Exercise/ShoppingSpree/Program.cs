using System.Diagnostics.Metrics;
using System.Threading;

namespace ShoppingSpree;

public class Program
{
    static void Main()
    {
        List<Person> people = new();
        List<Product> products = new();
        string[] data;
        try
        {
            data = Console.ReadLine().Split(new[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < data.Length; i += 2)
            {
                people.Add(new(data[i], int.Parse(data[i + 1])));
            }

            data = Console.ReadLine().Split(new[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < data.Length; i += 2)
            {
                products.Add(new(data[i], int.Parse(data[i + 1])));
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person person = people.First(x => x.Name == data[0]);
                Product product = products.First(x => x.Name == data[1]);

                if (person.Money >= product.Cost)
                {
                    person.Shopping(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                    continue;
                }
                Console.WriteLine($"{person.Name} can't afford {product.Name}");
            }

            foreach (var person in people)
                Console.WriteLine(person.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        
    }
}