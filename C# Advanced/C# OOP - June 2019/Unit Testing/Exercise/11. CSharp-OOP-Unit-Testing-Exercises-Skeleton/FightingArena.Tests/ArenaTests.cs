using System;
using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void TestFightingArenaConstructor()
        {
            Assert.IsNotNull(arena);
        }

        [Test]
        public void TestCountProperty()
        {
            Warrior warrior = new Warrior("Gosho", 1, 1);
            Warrior warrior2 = new Warrior("Pesho", 2 , 2);

            this.arena.Enroll(warrior);
            this.arena.Enroll(warrior2);

            var expectedWarriorsCount = 2;

            Assert.AreEqual(expectedWarriorsCount, this.arena.Count);
        }

        [Test]
        public void TestEnrollMethodException()
        {
            Warrior warrior = new Warrior("Vasko", 2, 2);
            Warrior warrior1 = new Warrior("Vasko", 2, 2);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(warrior1));
        }

        [Test]
        public void TestEnrollMethodWorksCorrectly()
        {
            Warrior warrior1 = new Warrior("Name1", 10, 30);
            Warrior warrior2 = new Warrior("Name2", 10, 10);

            this.arena.Enroll(warrior1);
            this.arena.Enroll(warrior2);
            Assert.AreEqual(2, this.arena.Count);
        }

        [Test]
        public void TestFightMethodPlayer1Exception()
        {
            Warrior warrior1 = new Warrior("Atanas", 10, 10);
            Warrior warrior2 = new Warrior("Petko", 12, 12);

            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Gosho", "Petko"));
        }

        [Test]
        public void TestFightMethodPlayer2Exception()
        {
            Warrior warrior1 = new Warrior("Ogi", 10, 10);
            Warrior warrior2 = new Warrior("Martin", 12, 12);

            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            Assert.Throws<InvalidOperationException>(() => this.arena.Fight("Ogi", "Ilyian"));
        }

        [Test]
        public void TestWorkMethodWorksCorrectly()
        {
            Warrior warrior1 = new Warrior("Tsvetan", 10, 50);
            Warrior warrior2 = new Warrior("Nikolay", 10, 80);

            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            arena.Fight("Tsvetan", "Nikolay");

            Assert.AreEqual(40, warrior1.HP);
            Assert.AreEqual(70, warrior2.HP);
        }
    }
}
