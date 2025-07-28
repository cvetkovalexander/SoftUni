using System;
using System.Security;
using System.Text;

namespace CarManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private Car MainCar;
        private double DefaultCapacity = 100;

        [SetUp]
        public void SetUp()
        {
            MainCar = new("Volkswagen", "Passat", 1.5, DefaultCapacity);
        }
        [Test]
        public void CarShouldBeInitializedProperly()
        {
            string make = "Mercedes";
            string model = "AMG";
            double fuelConsumption = 0.1;
            double fuelCapacity = 0.2;

            Car car = new(make, model, fuelConsumption, fuelCapacity);
            Assert.That(car.Make, Is.EqualTo(make));
            Assert.That(car.Model, Is.EqualTo(model));
            Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));
            Assert.That(car.FuelAmount, Is.Zero);
        }
        [TestCase(10), TestCase(20), TestCase(30)]
        public void RefuelMethodShouldWorkProperly(double fuel)
        {
            //Car car = new("Volkswagen", "Passat", 1.5, 100);
            
            MainCar.Refuel(fuel);
            Assert.That(MainCar.FuelAmount, Is.EqualTo(fuel));
        }
        [TestCase(101), TestCase(200), TestCase(300)]
        public void RefuelMethodShouldWorkProperlyIfGivenFuelIsMoreThatTheCarCapacity(double fuel)
        {
            //Car car = new("Volkswagen", "Passat", 1.5, 100);
            MainCar.Refuel(fuel);

            Assert.That(MainCar.FuelAmount, Is.EqualTo(MainCar.FuelCapacity));
        }

        [TestCase(0), TestCase(-1), TestCase(-10)]
        public void RefuelMethodShouldThrowAnExceptionIfGivenFuelIsZeroOrNegative(double fuel)
        {
            Assert.That(() => MainCar.Refuel(fuel), Throws.InstanceOf<ArgumentException>());
        }

        [TestCase(10), TestCase(20), TestCase(30)]
        public void DriveMethodShouldWorkProperly(double distance)
        {
            MainCar.Refuel(100);
            double neededFuel = (distance / 100) * MainCar.FuelConsumption;
            MainCar.Drive(distance);

            Assert.That(MainCar.FuelAmount, Is.EqualTo(DefaultCapacity - neededFuel));
        }
        [TestCase(10000), TestCase(20000), TestCase(30000)]
        public void DriveMethodShouldThrowAnExceptionIfNeededFuelIsBiggerThanFuelAmount(double distance)
        {
            MainCar.Refuel(100);
            
            Assert.That(() => MainCar.Drive(distance), Throws.InstanceOf<InvalidOperationException>());
        }

        [TestCase(null), TestCase("")]
        public void MakeSetterShouldThrowAnExceptionIfValueIsNullOrEmpty(string value)
        {
            Assert.That(() => new Car(value, "Test", 1, 1), Throws.InstanceOf<ArgumentException>());
        }

        [TestCase(null), TestCase("")]
        public void ModelSetterShouldThrowAnExceptionIfValueIsNullOrEmpty(string value)
        {
            Assert.That(() => new Car("Test", value, 1, 1), Throws.InstanceOf<ArgumentException>());
        }

        [TestCase(0), TestCase(-1), TestCase(-10)]
        public void FuelConsumptionSetterShouldThrowAnExceptionIfValueIsZeroOrNegative(double value)
        {
            Assert.That(() => new Car("Test", "Test", value, 1), Throws.InstanceOf<ArgumentException>());
        }

        [TestCase(0), TestCase(-10), TestCase(-20)]
        public void FuelCapacitySetterShouldThrowAnExceptionIfValueIsNegative(double value)
        {
            Assert.That(() => new Car("Test", "Test", 1, value), Throws.InstanceOf<ArgumentException>());
        }

        [TestCase(-1), TestCase(-20), TestCase(-30)]
        public void FuelAmountSetterShouldThrowAnExceptionIfValueIsNegative(double value)
        {
              
        }
    }
}