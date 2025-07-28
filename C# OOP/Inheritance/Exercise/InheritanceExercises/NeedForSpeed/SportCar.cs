using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed;

public class SportCar : Car
{
    public override double FuelConsumption => 10;

    public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
    {
    }
}
