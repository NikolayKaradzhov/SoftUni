using System;
using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person person;
        private ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            this.person = new Person(1, "Name");

            Person[] people = new Person[16];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Name{i}");
            }

            this.database = new ExtendedDatabase(people);
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
                Throws<ArgumentException>(() => this.database = new ExtendedDatabase(people));
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

        [Test]
        public void TestRemoveMethodWorksCorrectly()
        {
            int expectedCount = database.Count;

            for (int i = 0; i < expectedCount; i++)
            {
                database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void TestFindByUsernameMethodFirstException()
        {
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
        }

        [Test]
        public void TestFindByUsernameMethodSecondException()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("asdf"));
        }

        [Test]
        public void TestFindByUsernameMethodWorksCorrectly()
        {
            Assert.AreEqual(1, this.database.FindByUsername("Name1").Id);
            Assert.AreEqual("Name1", this.database.FindByUsername("Name1").UserName);
        }

        [Test]
        public void TestFindByIdMethodFirstException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1));
        }

        [Test]
        public void TestFindByIdMethodSecondException()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindById(123));
        }

        [Test]
        public void TestFindByIdReturnsCorrectResult()
        {
            Assert.AreEqual(1, this.database.FindById(1).Id);
            Assert.AreEqual("Name1", this.database.FindById(1).UserName);
        }
    }
}