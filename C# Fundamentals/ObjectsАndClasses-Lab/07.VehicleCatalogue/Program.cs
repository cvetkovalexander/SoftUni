namespace _07.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Catalogue catalogue = new();
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split('/');

                switch (command[0])
                {
                    case "Car":
                        Car car = new()
                        {
                            Brand = command[1],
                            Model = command[2],
                            HorsePower = double.Parse(command[3]),
                        };
                        catalogue.Cars.Add(car);
                        break;
                    case "Truck":
                        Truck truck = new()
                        {
                            Brand = command[1],
                            Model = command[2],
                            Weight = double.Parse(command[3])
                        };
                        catalogue.Trucks.Add(truck);
                        break;
                }
            }
            if (catalogue.Cars.Count > 0)
            {
                List<Car> orderedCars = catalogue.Cars.OrderBy(c => c.Brand).ToList();

                Console.WriteLine("Cars:");

                foreach (var car in orderedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (catalogue.Trucks.Count > 0)
            {
                List<Truck> orderedTrucks = catalogue.Trucks.OrderBy(c => c.Brand).ToList();

                Console.WriteLine("Trucks:");

                foreach (var truck in orderedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }

    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Weight { get; set; }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double HorsePower { get; set; }
    }

    class Catalogue
    {
        public Catalogue()
        {
            Cars = new List<Car>();
            Trucks = new List<Truck>();
        }

        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }
}
