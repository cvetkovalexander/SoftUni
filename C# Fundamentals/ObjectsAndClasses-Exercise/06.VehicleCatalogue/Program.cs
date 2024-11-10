namespace _06.VehicleCatalogue
{
    class Vehicle
    {

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public decimal HP { get; set; }
        public Vehicle(string type, string model, string color, decimal hp)
        {
            Type = type == "car" ? "Car" : "Truck";
            Model = model;
            Color = color;
            HP = hp;
        }

        public override string ToString()
        {
            return $"Type: {Type}\n" +
                   $"Model: {Model}\n" +
                   $"Color: {Color}\n" +
                   $"Horsepower: {HP}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> catalogue = new();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split();
                catalogue.Add(new(command[0], command[1], command[2], decimal.Parse(command[3])));
            }

            while ((input = Console.ReadLine()) != "Close the Catalogue")
            {
                foreach (Vehicle vehicle in catalogue)
                {
                    if (vehicle.Model == input)
                    {
                        Console.WriteLine(vehicle);
                    }
                }
            }

            PrintAverageByType(catalogue, "Car");
            PrintAverageByType(catalogue, "Truck");
        }

        private static void PrintAverageByType(List<Vehicle> catalogue,string vehicleType)
        {
            decimal sum = 0, counter = 0;
            foreach (Vehicle vehicle in catalogue)
            {
                if (vehicle.Type == vehicleType)
                {
                    counter++;
                    sum += vehicle.HP;
                }
            }
            decimal average = counter > 0 ? sum / counter : 0;
            Console.WriteLine($"{vehicleType}s have average horsepower of: {average:F2}.");
        }
    }
}
