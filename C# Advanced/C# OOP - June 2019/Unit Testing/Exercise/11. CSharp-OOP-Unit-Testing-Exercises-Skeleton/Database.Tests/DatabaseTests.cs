using System;
using Database;
using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private Database database;
        private int[] data = new int[] { 1, 2 };

        [SetUp]
        public void Setup()
        {
            this.database = new Database( this.data );
        }
         
        [Test]
        public void TestDatabaseCapacity()
        {
            int expectedCount = 2;

            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void TestAddingCorrectly()
        {
            int expectedCount = 3;

            this.database.Add(3);

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void TestAddingWhenFull()
        {
            for (int i = 3; i <= 16; i++)
            {
                this.database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(17);
            });
        }

        [Test]
        public void TestRemovingElementCorrectly()
        {
            int expectedCount = 1;

            database.Remove();

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void TestIfDatabaseIsEmpty()
        {
            database.Remove();
            database.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Remove();
            });

            //Assert.That(database.Remove, 
            //    Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));
        }

        [Test]
        public void TestFetchMethodIfWorksCorrectly()
        {
            int[] result = this.database.Fetch();
            CollectionAssert.AreEqual(this.data, result);
        }
    } 
}