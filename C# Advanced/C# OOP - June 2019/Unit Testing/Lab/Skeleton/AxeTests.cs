using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummyTarget;

        [SetUp]
        public void CreateAxe()
        {
            axe = new Axe(100, 1);
        }

        [SetUp]
        public void CreateDummy()
        {
            dummyTarget = new Dummy(100, 100);
        }

        [Test]
        public void TestAxeLosingDurability()
        {
            axe.Attack(dummyTarget);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(0));
        }

        [Test]
        public void TestAttackingWithBrokenWeapon()
        {
            Axe axe = new Axe(1, 1);
            Dummy dummy = new Dummy(100, 100);

            axe.Attack(dummy);

            Assert.That(() => axe.Attack(dummy),
                Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }
    }
}