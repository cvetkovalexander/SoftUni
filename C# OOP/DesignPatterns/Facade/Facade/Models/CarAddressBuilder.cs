using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Models;

public class CarAddressBuilder : CarBuilderFacade
{
    public CarAddressBuilder(Car car)
    {
        this.Car = car;
    }

    public CarAddressBuilder InCity(string city)
    {
        this.Car.City = city;
        return this;
    }

    public CarAddressBuilder AtAddress(string address)
    {
        this.Car.Address = address;
        return this;
    }
}