using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Models;

public class CarBuilderFacade
{
    protected Car Car { get; set; }

    public CarBuilderFacade()
    {
        this.Car = new();
    }

    public Car Build() => this.Car;

    public CarInfoBuilder Info => new CarInfoBuilder(Car);
    public CarAddressBuilder Address => new CarAddressBuilder(Car);
}