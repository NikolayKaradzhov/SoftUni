using System;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("BMW", "E90", 10, 70);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.AreEqual("BMW", this.car.Make);
            Assert.AreEqual("E90", this.car.Model);
            Assert.AreEqual(10, this.car.FuelConsumption);
            Assert.AreEqual(70, this.car.FuelCapacity);
            Assert.AreEqual(0, this.car.FuelAmount);
        }
        [Test]
        public void TestMakePropertyWorksCorrectly()
        {
            Assert.Throws<ArgumentException>(() => new Car(null, "e46", 8.9, 10));
        }

        [Test]
        public void TestModelPropertyWorksCorrectly()
        {
            Assert.Throws<ArgumentException>(() => new Car("Mercedes", null, 10, 10));
        }

        [Test]
        public void TestFuelConsumptionPropertyWorksCorrectly()
        {
            Assert.Throws<ArgumentException>(() => new Car("Cadillac", "Eldorado", 0, 10));
        }

        [Test]
        public void TestFuelAmountPropertyWorksCorrectly()
        {
            Assert.Throws<ArgumentException>(() => new Car("Ford", "Mustang", 10, 0));
        }

        [Test]
        public void TestRefuelMethodExceptionWorksCorrectly()
        {
            Assert.Throws<ArgumentException>(() => this.car.Refuel(0));
        }

        [Test]
        public void TestRefuelMethodWorksCorrectly()
        {
            double expectedFuelAmount = 10;

            this.car.Refuel(10);

            Assert.AreEqual(expectedFuelAmount, this.car.FuelAmount);
        }

        [Test]
        public void TestRefuelMethodOverfuelCapacity()
        {
            double expectedFuelAmount = 70;

            this.car.Refuel(80);

            Assert.AreEqual(expectedFuelAmount, this.car.FuelAmount);
        }

        [Test]
        public void TestDriveMethodExceptionWorksCorrectly()
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(1000));
        }

        [Test]
        public void TestDriveMethodWorksCorrectly()
        {
            car.Refuel(1);
            car.Drive(1);

            Assert.AreEqual(0.9, this.car.FuelAmount);
        }
    }
}