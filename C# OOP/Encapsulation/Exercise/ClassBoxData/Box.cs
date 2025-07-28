using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBoxData;

public class Box
{
    public Box(double length, double width, double height)
    {
        if (length <= 0) throw new ArgumentException($"Length cannot be zero or negative.");
        if (width <= 0) throw new ArgumentException($"Width cannot be zero or negative.");
        if (height <= 0) throw new ArgumentException($"Height cannot be zero or negative.");

        this.Length = length;
        this.Width = width;
        this.Height = height;
    }
    public double Length { get; }
    public double Width { get; }
    public double Height { get; }

    public double SurfaceArea() 
        => (2 * this.Length * this.Width) + (2 * this.Height * this.Length) + (2 * this.Width * this.Height);

    public double LateralSurfaceArea() 
        => (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
    public double Volume() 
        => this.Height * this.Width * this.Length;
}