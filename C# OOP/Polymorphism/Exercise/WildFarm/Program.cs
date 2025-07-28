using WildFarm.Abstraction.ForAnimals;
using WildFarm.Abstraction.ForFoods;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;

namespace WildFarm;
public class Program
{
    static void Main()
    {
        List<Animal> animals = new();
        string animalInput;
        while ((animalInput = Console.ReadLine()) != "End")
        {
            string foodInput = Console.ReadLine();
            Animal animal = ParseAnimal(animalInput);
            Food food = ParseFood(foodInput);

            Console.WriteLine(animal.ProduceSound());

            if (!animal.Eat(food))
                Console.WriteLine($"{animal.GetType().Name} does not eat {food.GetType().Name}!");

            animals.Add(animal);
        }

        foreach (var animal in animals)
            Console.WriteLine(animal);
    }

    private static Animal ParseAnimal(string input)
    {
        string[] data = input.Split();
        string type = data[0];
        string name = data[1];
        double weight = double.Parse(data[2]);

        Animal animal = type switch
        {
            nameof(Cat) => new Cat(name, weight, data[3], data[4]),
            nameof(Tiger) => new Tiger(name, weight, data[3], data[4]),
            nameof(Hen) => new Hen(name, weight, double.Parse(data[3])),
            nameof(Owl) => new Owl(name, weight, double.Parse(data[3])),
            nameof(Mouse) => new Mouse(name, weight, data[3]),
            nameof(Dog) => new Dog(name, weight, data[3]),
            _ => throw new ArgumentException("Invalid type of animal!")
        };

        return animal;
    }

    private static Food ParseFood(string input)
    {
        string[] data = input.Split();

        string type = data[0];
        int quantity = int.Parse(data[1]);

        Food food = type switch
        {
            nameof(Fruit) => new Fruit(quantity),
            nameof(Meat) => new Meat(quantity),
            nameof(Seeds) => new Seeds(quantity),
            nameof(Vegetable) => new Vegetable(quantity),
            _ => throw new ArgumentException("Invalid type of food!")
        };

        return food;
    }
}