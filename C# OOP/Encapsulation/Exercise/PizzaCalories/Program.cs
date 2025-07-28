using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace PizzaCalories;

public class Program
{
    static void Main()
    {
        try
        {
            Pizza pizza = GetPizzaName();
            pizza.Dough = ReadDough();
            foreach (var topping in ReadToppings())
                pizza.AddTopping(topping);
            Console.WriteLine(pizza.ToString());
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static Dough ReadDough()
    {
        string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        if (data[0] != "Dough") throw new InvalidOperationException("Invalid input (dough)!");

        return new(data[1], data[2], double.Parse(data[3]));
    }

    private static IEnumerable<Topping> ReadToppings()
    {
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (data[0] != "Topping") throw new InvalidOperationException("Invalid input (topping)!");

            yield return new(data[1], double.Parse(data[2]));
        }

    }

    private static Pizza GetPizzaName()
    {
        string[] data = Console.ReadLine().Split(" ");

        if (data[0] != "Pizza") throw new InvalidOperationException("Invalid input (pizza)!");

        return new(data[1]);
    }
}
