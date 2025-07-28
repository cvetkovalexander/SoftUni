using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Models;

public class Car
{
    //public Car(string type, string color, int numberOfDoors, string city, string address)
    //{
    //    this.Type = type;
    //    this.Color = color;
    //    this.NumberOfDoors = numberOfDoors;
    //    this.City = city;
    //    this.Address = address;
    //}

    public string Type { get; set; }
    public string Color { get; set; }
    public int NumberOfDoors { get; set; }
    public string City { get; set; }
    public string Address { get; set; }

    public override string ToString()
        =>
            $"CarType: {this.Type}, Color: {this.Color}, Number of doors: {this.NumberOfDoors}, Manufactured in {this.City}, at address: {this.Address}";
}