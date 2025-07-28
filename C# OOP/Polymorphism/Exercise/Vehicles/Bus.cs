using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles;

public class Bus : BaseVehicle
{
    public override double FuelConsumption => base.FuelConsumption + 1.4;

    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
    }

    public string DriveEmpty(double distance)
    {
        var requiredFuel = distance * (this.FuelConsumption - 1.4);
        if (this.FuelQuantity < requiredFuel) return $"{this.GetType().Name} needs refueling";

        this.FuelQuantity -= requiredFuel;
        return $"{this.GetType().Name} travelled {distance} km";
    }
}