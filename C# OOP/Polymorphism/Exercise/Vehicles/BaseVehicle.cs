using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles;
public abstract class BaseVehicle : IVehicle
{
    public double TankCapacity { get; }
    public double FuelQuantity { get; protected set; }
    public virtual double FuelConsumption { get; }


    protected BaseVehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        if (fuelQuantity > tankCapacity)
            fuelQuantity = 0;
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
        this.TankCapacity = tankCapacity;
    }


    public string Drive(double distance)
    {
        //if (distance < 0) throw new ArgumentException("Distance cannot be negative");

        var requiredFuel = distance * this.FuelConsumption;
        if (this.FuelQuantity < requiredFuel) return $"{this.GetType().Name} needs refueling";

        this.FuelQuantity -= requiredFuel;
        return $"{this.GetType().Name} travelled {distance} km";
    }

    public virtual bool Refuel(double liters)
    {
        if (liters <= 0) throw new ArgumentException("Fuel must be a positive number");
        if (this.FuelQuantity + liters > this.TankCapacity) return false;
        this.FuelQuantity += liters;
        return true;
    }

    public override string ToString() => $"{this.GetType().Name}: {this.FuelQuantity:F2}";

}