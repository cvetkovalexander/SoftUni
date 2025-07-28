using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles;

public class Truck : BaseVehicle
{
    public override double FuelConsumption 
        => base.FuelConsumption + 1.6;

    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
    }
    

    public override bool Refuel(double liters)
        => base.Refuel(liters * 0.95);
}