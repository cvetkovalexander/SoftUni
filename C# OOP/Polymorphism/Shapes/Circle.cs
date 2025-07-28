using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes;

public class Circle : Shape
{
    public double Radius { get; }

    public Circle(double radius)
    {
        this.Radius = radius;
    }
    public override double CalculatePerimeter()
        => 2 * Math.PI * this.Radius;

    public override double CalculateArea()
        => Math.PI * Math.Pow(this.Radius, 2);
}