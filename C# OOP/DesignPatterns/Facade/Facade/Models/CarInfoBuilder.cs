using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Models;

public class CarInfoBuilder : CarBuilderFacade
{
    public CarInfoBuilder(Car car)
    {
        this.Car = car;
    }

    public CarInfoBuilder WithType(string type)
    {
        this.Car.Type = type;
        return this;
    }

    public CarInfoBuilder WithColor(string color)
    {
        this.Car.Color = color;
        return this;
    }

    public CarInfoBuilder WithNumberOfDoors(int numOfDrs)
    {
        this.Car.NumberOfDoors = numOfDrs;
        return this;
    }
}