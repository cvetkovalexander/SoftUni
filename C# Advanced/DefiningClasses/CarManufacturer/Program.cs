namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main()
        {
            List<Engine> engines = new();
            List<Tire[]> tires = new(); List<Car> cars = new();
            string[] data;
            string input;
            while ((input = Console.ReadLine()) != "No more tires")
            {
                data = input.Split();
                var tiresArr = new Tire[]
                {
                    new Tire(int.Parse(data[0]), double.Parse(data[1])),
                    new Tire(int.Parse(data[2]), double.Parse(data[3])),
                    new Tire(int.Parse(data[4]), double.Parse(data[5])),
                    new Tire(int.Parse(data[6]), double.Parse(data[7]))

                };
                tires.Add(tiresArr);
            }

            while ((input = Console.ReadLine()) != "Engines done")
            {
                data = input.Split();
                int hPower = int.Parse(data[0]);
                double cCapacity = double.Parse(data[1]);
                Engine engine = new(hPower, cCapacity);
                engines.Add(engine);
            }

            while ((input = Console.ReadLine()) != "Show special")
            {
                data = input.Split();
                string make = data[0], model = data[1];
                int year = int.Parse(data[2]); double quantity = double.Parse(data[3]), consumption =
                    double.Parse(data[4]);
                int engineIndex = int.Parse(data[5]), tiresIndex = int.Parse(data[6]);
                Car car = new(make, model, year, quantity, consumption, engines[engineIndex], tires[tiresIndex]);
                cars.Add(car);
            }

            foreach (var car in cars)
            {
                double pressureSum = car.Tires.Sum(t => t.Pressure);
                //foreach (var tire in car.Tires)
                //{
                //    pressureSum += tire.Pressure;
                //}
                if (car.Year >= 2017 && car.Engine.HorsePower > 330 && (pressureSum >= 9 && pressureSum <= 10))
                {
                    car.Drive(20);
                    Console.WriteLine(car.WhoAmI());
                }
            }
        }
    }
}