namespace RawData;

public class Program
{
    static void Main(string[] args)
    {
        List<Car> cars = new();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] data = Console.ReadLine().Split();
            string model = data[0];
            int speed = int.Parse(data[1]);
            int power = int.Parse(data[2]), weight = int.Parse(data[3]); string type = data[4];
            Engine engine = new(speed, power);
            Cargo cargo = new(weight, type);
            var tires = new Tires[]
            {
                new Tires(double.Parse(data[5]), int.Parse(data[6])),
                new Tires(double.Parse(data[7]), int.Parse(data[8])),
                new Tires(double.Parse(data[9]), int.Parse(data[10])),
                new Tires(double.Parse(data[11]), int.Parse(data[12])),
            };
            cars.Add(new(model, engine, cargo, tires));
        }
        string command = Console.ReadLine();
        if (command == "fragile")
        {
            PrintFragile(cars);
        }
        else
        {
            PrintFlammable(cars);
        }
    }

    private static void PrintFlammable(List<Car> cars)
    {
        foreach (var car in cars.Where(c => c.Cargo.Type == "flammable").Where(c => c.Engine.Power > 250))
        {
            Console.WriteLine(car);
        }
    }

    public static void PrintFragile(List<Car> cars)
    {
        foreach (var car in cars.Where(c => c.Cargo.Type == "fragile"))
        {
            bool isValid = false;
            foreach (var tire in car.Tires)
            {
                if (tire.Pressure < 1)  
                {
                    isValid = true;
                    break;
                }
            }

            if (isValid)
            {
                Console.WriteLine(car);
            }
        }
    }
}