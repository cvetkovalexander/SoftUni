using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles;
public class Car : BaseVehicle
{
    public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
    }

    public override double FuelConsumption 
        => base.FuelConsumption + 0.9;

    
}