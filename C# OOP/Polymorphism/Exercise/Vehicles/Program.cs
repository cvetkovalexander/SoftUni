using System.Threading.Channels;

namespace Vehicles;
public class Program
{
    private static readonly Dictionary<string, Func<double, double, double, IVehicle>> _factories = new()
    {
        [nameof(Car)] = (x, y, z) => new Car(x, y, z),
        [nameof(Truck)] = (x, y, z) => new Truck(x, y, z),
        [nameof(Bus)] = (x, y, z) => new Bus(x, y, z),

    };
    public static void Main(string[] args)
    {
        Dictionary<string, IVehicle> vehiclesMap = GetVehicles();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string command = Console.ReadLine();
            try
            {
                ExecuteCommand(command, vehiclesMap);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        foreach (var vehicle in vehiclesMap.Values)
            Console.WriteLine(vehicle);
    }

    private static void ExecuteCommand(string command, Dictionary<string, IVehicle> vehiclesMap)
    {
         string[] data = command.Split(" ",StringSplitOptions.RemoveEmptyEntries);
         
         IVehicle vehicle = vehiclesMap[data[1]]; 
         switch (data[0])
         {
             case "Drive":
                 Console.WriteLine(vehicle.Drive(double.Parse(data[2])));
                 break;
             case "Refuel":
                 if (!vehicle.Refuel(double.Parse(data[2])))
                     Console.WriteLine($"Cannot fit {data[2]} fuel in the tank");
                 break;
            case "DriveEmpty":
                 Console.WriteLine(((Bus)vehicle).DriveEmpty(double.Parse(data[2])));
                 break;
         }
        
    }

    private static Dictionary<string, IVehicle> GetVehicles()
    {
        Dictionary<string, IVehicle> vehiclesMap = new();
        for (int i = 0; i < 3; i++)
        {
            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string vehicleType = data[0];
            Func<double, double, double, IVehicle> factory = _factories[vehicleType];
            IVehicle vehicle = factory(double.Parse(data[1]), double.Parse(data[2]), double.Parse(data[3]));
            vehiclesMap[vehicleType] = vehicle;

            //vehiclesMap[data[0]] = data[0] switch
            //{
            //    "Car" => new Car(double.Parse(data[1]), double.Parse(data[2]), double.Parse(data[3])),
            //    "Truck" => new Truck(double.Parse(data[1]), double.Parse(data[2]), double.Parse(data[3])),
            //    "Bus" => new Bus(double.Parse(data[1]), double.Parse(data[2]), double.Parse(data[3])),
            //    _ => vehiclesMap[data[0]]
            //};
        }

        return vehiclesMap;
    }
}
