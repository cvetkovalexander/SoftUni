using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes;

public class Rectangle : Shape
{
    public double Height { get; }
    public double Width { get; }

    public Rectangle(double height, double width)
    {
        this.Height = height;
        this.Width = width;
    }
    public override double CalculatePerimeter()
        => 2 * (Height + Width);

    public override double CalculateArea()
        => Height * Width;

}