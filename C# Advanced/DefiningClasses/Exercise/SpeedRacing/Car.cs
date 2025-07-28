using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRacing;

public class Car
{
    public override string ToString()
    {
        return $"{Model} {FuelAmount:F2} {TravelledDistance}";
    }

    public Car(string model, double fuel, double consumption)
    {
        Model = model;
        FuelAmount = fuel;
        FuelConsumptionPerKilometer = consumption;
        TravelledDistance = 0;
    }
    public string Model { get; set; }

    public double FuelAmount { get; set; }

    public double FuelConsumptionPerKilometer { get; set; }

    public double TravelledDistance { get; set; }

    public void Drive(double distance)
    {
        if (FuelAmount - distance * FuelConsumptionPerKilometer < 0)
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
        else
        {
            FuelAmount -= distance * FuelConsumptionPerKilometer;
            TravelledDistance += distance;
        }
    }

}