using Facade.Models;

namespace Facade;

public class Program
{
    static void Main(string[] args)
    {
        var car = new CarBuilderFacade().Info.WithType("BMW").WithColor("Red").WithNumberOfDoors(4).Address
            .InCity("Karlovo").AtAddress("Address 1").Build();

        Console.WriteLine(car);
    }
}