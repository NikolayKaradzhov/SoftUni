using System;
using System.Collections.Generic;
using NUnit.Framework;
using ExtendedDatabase;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person person;
        private ExtendedDatabase.ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            this.person = new Person(1, "Name");

            Person[] people = new Person[16];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Name{i}");
            }

            this.database = new ExtendedDatabase.ExtendedDatabase(people);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.AreEqual(1, this.person.Id);
            Assert.AreEqual("Name", this.person.UserName);
        }

        [Test]
        public void TestDatabaseCount()
        {
            int expectedResult = 16;

            Assert.AreEqual(expectedResult, this.database.Count);
        }

        [Test]
        public void TestAddRangeException()
        {
            Person[] people = new Person[17];

            Assert.
                Throws<ArgumentException>(() => this.database = new ExtendedDatabase.ExtendedDatabase(people));
        }

        [Test]
        public void TestAddMethodFirstException()
        {
            Person added17ThPerson = new Person(42, "Vasko");

            Assert.Throws<InvalidOperationException>(() => this.database.Add(person));
        }

        [Test]
        public void TestAddMethodSecondExceptionWithSameName()
        {
            this.database.Remove();

            Person person = new Person(23, "Name1");

            Assert.Throws<InvalidOperationException>(() => database.Add(person));
        }

        [Test]
        public void TestAddMethodThirdExceptionWithSameId()
        {
            database.Remove();

            Person testPerson = new Person(1, "Kristyan");

            Assert.Throws<InvalidOperationException>(() => database.Add(testPerson));
        }
    }
}