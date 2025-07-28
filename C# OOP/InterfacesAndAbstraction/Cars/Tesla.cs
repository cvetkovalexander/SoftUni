using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars;

public class Tesla : IElectricCar, ICar
{
    public Tesla(string model, string color, int battery)
    {
        Battery = battery;
        Model = model;
        Color = color;
    }

    public int Battery { get; }
    public string Model { get; }
    public string Color { get; }
    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        return $"{this.Color} Tesla {this.Model} with {this.Battery} Batteries";
    }
}