using System;
using NUnit.Framework;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test_Add_Rider_Method()
        {
            //Arrange
            RaceEntry firstEntry = new RaceEntry();
            UnitMotorcycle motorcycle = new UnitMotorcycle("Honda", 115, 125);
            UnitRider rider = new UnitRider("Gosho", motorcycle);

            //Act
            string actualMessage = firstEntry.AddRider(rider);

            //Assert
            string expectedMessage = "Rider Gosho added in race.";
            Assert.AreEqual(expectedMessage, actualMessage);

            Assert.AreEqual(firstEntry.Counter, 1);
        }

        [Test]
        public void Test_Add_Rider_Method_First_Exception()
        {
            UnitMotorcycle motorcycle = new UnitMotorcycle("Honda", 115, 125);

            RaceEntry race = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() => race.AddRider(null));
        }

        [Test]
        public void Test_Add_Rider_Method_Second_Exception()
        {
            UnitMotorcycle motorcycle = new UnitMotorcycle("Honda", 115, 125);
            UnitRider rider = new UnitRider("Gosho", motorcycle);

            RaceEntry race = new RaceEntry();

            race.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() => race.AddRider(rider));
        }

        [Test]
        public void Test_Calculate_Average_Horsepower_Method_Exception()
        {
            RaceEntry race = new RaceEntry();
            UnitMotorcycle motorcycle = new UnitMotorcycle("honda", 100, 120);
            UnitRider rider = new UnitRider("vasko", motorcycle);

            race.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
        }

        [Test]
        public void Test_Calculate_Average_Horsepower_Method()
        {
            RaceEntry race = new RaceEntry();

            UnitMotorcycle motorcycle = new UnitMotorcycle("honda", 100, 120);
            UnitRider rider = new UnitRider("vasko", motorcycle);
            UnitMotorcycle motorcycle1 = new UnitMotorcycle("kawasaki", 100, 120);
            UnitRider rider1 = new UnitRider("ivan", motorcycle1);
            UnitMotorcycle motorcycle2 = new UnitMotorcycle("piaggio", 100, 120);
            UnitRider rider2 = new UnitRider("goshos", motorcycle2);

            race.AddRider(rider);
            race.AddRider(rider1);
            race.AddRider(rider2);

            Assert.AreEqual(100, race.CalculateAverageHorsePower());
        }
    }
}