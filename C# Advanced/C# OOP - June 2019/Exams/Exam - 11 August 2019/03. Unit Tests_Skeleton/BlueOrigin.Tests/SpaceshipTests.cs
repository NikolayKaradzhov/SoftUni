using System.Collections.Generic;

namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private List<Astronaut> astronaunts;

        [Test]
        public void Test_Spaceship_Constructor()
        {
            Spaceship spaceship = new Spaceship("Apolo", 10);

            astronaunts = new List<Astronaut>();
        }

        [Test]
        public void Test_Count_Property()
        {
            Spaceship spaceship = new Spaceship("Apolo", 1);

            Astronaut astronaunt1 = new Astronaut("Gosho", 1.1);

            spaceship.Add(astronaunt1);

            Assert.AreEqual(1, spaceship.Count);
        }

        [Test]
        public void TestAddMethod_First_Exception()
        {
            Spaceship spaceship = new Spaceship("Apolo", 2);

            Astronaut astronaut1 = new Astronaut("Gosho", 1.0);
            Astronaut astronaut2 = new Astronaut("Pesho", 1.0);
            Astronaut astronaut3 = new Astronaut("Vasko", 1.0);

            spaceship.Add(astronaut1);
            spaceship.Add(astronaut2);

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut3));
        }

        [Test]
        public void TestAddMethod_Second_Exception()
        {
            Spaceship spaceship = new Spaceship("Apolo", 3);

            Astronaut astronaut1 = new Astronaut("Gosho", 1.0);
            Astronaut astronaut2 = new Astronaut("Pesho", 1.0);

            spaceship.Add(astronaut1);
            spaceship.Add(astronaut2);

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut2));
        }

        [Test]
        public void TestAddMethod_Second_Exception_FalseBool()
        {
            Spaceship spaceship = new Spaceship("Apolo", 3);

            Astronaut astronaut1 = new Astronaut("Gosho", 1.0);
            Astronaut astronaut2 = new Astronaut("Pesho", 1.0);
            Astronaut astronaut3 = new Astronaut("Vasko", 1.0);

            spaceship.Add(astronaut1);
            spaceship.Add(astronaut2);

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut2));
        }

        [Test]
        public void Test_Remove_Method()
        {
            Spaceship spaceship = new Spaceship("Apolo", 2);
            Astronaut astronaut1 = new Astronaut("Gosho", 1.0);
            spaceship.Add(astronaut1);

            spaceship.Remove("Gosho");
        }

        [Test]
        public void Test_Remove_Method_False()
        {
            Spaceship spaceship = new Spaceship("Apolo", 2);
            Astronaut astronaut1 = new Astronaut("Gosho", 1.0);

            spaceship.Add(astronaut1);

            Assert.AreEqual(false, spaceship.Remove("Vasko"));
        }

        [Test]
        public void Test_Capacity()
        {
            Assert.Throws<ArgumentException>(() => new Spaceship("Apolo", -1));
        }

        [Test]
        public void Test_Spaceship_Name()
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(null, 1));
        }

        [Test]
        public void Test_Name_Property()
        {
            Spaceship spaceship = new Spaceship("Apolo", 2);

            Assert.AreEqual("Apolo", spaceship.Name);
        }

        [Test]
        public void Test_Spaceship_Capacity()
        {
            Spaceship spaceship = new Spaceship("Apolo", 2);

            Assert.AreEqual(2, spaceship.Capacity);
        }
    }
}