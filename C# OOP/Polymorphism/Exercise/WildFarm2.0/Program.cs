using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace WildFarm2._0;

public class Program
{
    private static readonly Dictionary<string, Func<int, BaseFood>> _factories = new()
    {
        [nameof(Vegetable)] = (x) => new Vegetable(x),
        [nameof(Fruit)] = (x) => new Fruit(x),
        [nameof(Seeds)] = (x) => new Seeds(x),
        [nameof(Meat)] = (x) => new Meat(x)
    };
    static void Main(string[] args)
    {
        List<BaseAnimal> animals = new();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string animalInput = input;
            BaseAnimal animal = ParseAnimal(animalInput);
            string foodInput = Console.ReadLine();
            BaseFood food = ParseFood(foodInput);

            Console.WriteLine(animal.AskForFood());
            if (!animal.Eat(food))
                Console.WriteLine($"{animal.GetType().Name} does not eat {food.GetType().Name}!");
            
            animals.Add(animal);
        }

        foreach (var animal in animals)
            Console.WriteLine(animal);
    }


    private static BaseAnimal ParseAnimal(string input)
    {
        string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string type = data[0];
        string name = data[1];
        double weight = double.Parse(data[2]);

        return type switch
        {
            nameof(Cat) => new Cat(name, weight, data[3], data[4]),
            nameof(Tiger) => new Tiger(name, weight, data[3], data[4]),
            nameof(Owl) => new Owl(name, weight, double.Parse(data[3])),
            nameof(Hen) => new Hen(name, weight, double.Parse(data[3])),
            nameof(Mouse) => new Mouse(name, weight, data[3]),
            nameof(Dog) => new Dog(name, weight, data[3]),
            _ => throw new InvalidOperationException("Invalid type of animal!")
        };
    }

    private static BaseFood ParseFood(string input)
    {
        string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string type = data[0];
        int quantity = int.Parse(data[1]);

        Func<int, BaseFood> factory = _factories[type];
        BaseFood food = factory(quantity);
        return food;

        //return type switch
        //{
        //    nameof(Vegetable) => new Vegetable(quantity),
        //    nameof(Seeds) => new Seeds(quantity),
        //    nameof(Fruit) => new Fruit(quantity),
        //    nameof(Meat) => new Meat(quantity),
        //    _ => throw new InvalidOperationException("Invalid type of food!")
        //};
    }
}