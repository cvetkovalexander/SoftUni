using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman;

public class Car
{
    public override string ToString()
    {
        StringBuilder result = new();
        result.AppendLine($"{Model}:");
        result.AppendLine(Engine.ToString());
        result.AppendLine($"  Weight: {Weight?.ToString() ?? "n/a"}");
        result.Append($"  Color: {Color ?? "n/a"}");

        return result.ToString();
    }

    public Car(string model, Engine engine, int? weight, string? color)
    {
        Model = model;
        Engine = engine;
        Weight = weight;
        Color = color;
    }
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public int? Weight { get; set; }
    public string? Color { get; set; }
}