﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed;

public class Vehicle
{
    public double Fuel { get; set; }
    public int HorsePower { get; set; }
    public double DefaultFuelConsumption => 1.25;
    public virtual double FuelConsumption => DefaultFuelConsumption;
    public Vehicle(int horsePower, double fuel)
    {
        this.HorsePower = horsePower;
        this.Fuel = fuel;
    }
    public virtual void Drive(double kilometers)
    {
        this.Fuel -= kilometers * this.FuelConsumption;
    }
}
