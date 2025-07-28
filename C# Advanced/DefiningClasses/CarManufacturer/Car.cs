using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CarManufacturer
{
    public class Car
    {
        public Car(string make, string model, int year, double quantity, double consumption, Engine engine, Tire[] tires): this(make, model, year, quantity, consumption)
        {
            Engine = engine;
            Tires = tires;
        }
        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }
        public Car(string make, string model, int year) : this()
        {
            Make = make;
            Model = model;
            Year = year;
        }
        public Car(string make, string model, int year, double quantity, double consumption): this(make, model, year)
        {
            FuelQuantity = quantity;
            FuelConsumption = consumption;
        }
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public Engine Engine { get; set; }
        public Tire[] Tires { get; set; }

        public void Drive(double distance)
        {
            if (FuelQuantity - distance * (FuelConsumption / 100) < 0)
            {
                Console.WriteLine("Not enough fuel to perform the trip!");
            }
            else
            {
                FuelQuantity -= distance * (FuelConsumption / 100);
            }
        }
        public string WhoAmI()
        {
            return $"Make: {Make}\nModel: {Model}\nYear: {Year}\nHorsePowers: {Engine.HorsePower}\nFuelQuantity: {FuelQuantity}";
        }
    }
}
