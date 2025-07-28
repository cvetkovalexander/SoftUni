using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CarSalesman;

public class Engine
{
    public override string ToString()
    {
        StringBuilder result = new();
        result.AppendLine($"  {Model}:");
        result.AppendLine($"    Power: {Power}");
        result.AppendLine($"    Displacement: {Displacement?.ToString() ?? "n/a"}");
        result.Append($"    Efficiency: {Efficiency ?? "n/a"}");
        return result.ToString();
    }

    public Engine(string model, int power, int? displacement, string? efficiency)
    {
        Model = model;
        Power = power;
        Displacement = displacement;
        Efficiency = efficiency;
    }
    public string Model { get; set; }
    public int Power { get; set; }
    public int? Displacement { get; set; }
    public string? Efficiency { get; set; }
}