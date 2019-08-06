using System;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior("Name", 10, 10);
        }

        [Test]
        public void TestConstructorWorksProperly()
        {
            Assert.AreEqual("Name", this.warrior.Name);
            Assert.AreEqual(10, this.warrior.Damage);
            Assert.AreEqual(10, this.warrior.HP);
        }

        [Test]
        public void TestName()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(null, 10, 10));
        }

        [Test]
        public void TestDamage()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Name", 0, 10));
        }

        [Test]
        public void TestHP()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Name", 10, -10));
        }

        [Test]
        public void TestAttackFirstException()
        {
            Warrior warrior1 = new Warrior("Name1", 10, 30);
            Warrior warrior2 = new Warrior("Name2", 10, 40);
            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
        }

        [Test]
        public void TestAttackSecondException()
        {
            Warrior warrior1 = new Warrior("Name1", 10, 40);
            Warrior warrior2 = new Warrior("Name2", 10, 30);
            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
        }

        [Test]
        public void TestAttackThirdException()
        {
            Warrior warrior1 = new Warrior("Name1", 10, 40);
            Warrior warrior2 = new Warrior("Name2", 50, 50);
            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
        }

        [Test]
        public void TestAttackThisHP()
        {
            Warrior warrior1 = new Warrior("Name1", 41, 35);
            Warrior warrior2 = new Warrior("Name2", 34, 40);
            warrior1.Attack(warrior2);
            Assert.AreEqual(1, warrior1.HP);
        }

        [Test]
        public void TestAttackIfStatment()
        {
            Warrior warrior1 = new Warrior("Name1", 41, 35);
            Warrior warrior2 = new Warrior("Name2", 34, 40);
            warrior1.Attack(warrior2);
            Assert.AreEqual(0, warrior2.HP);
        }

        [Test]
        public void TestAttackElseStatment()
        {
            Warrior warrior1 = new Warrior("Name1", 39, 35);
            Warrior warrior2 = new Warrior("Name2", 34, 40);
            warrior1.Attack(warrior2);
            Assert.AreEqual(1, warrior2.HP);
        }
    }
}