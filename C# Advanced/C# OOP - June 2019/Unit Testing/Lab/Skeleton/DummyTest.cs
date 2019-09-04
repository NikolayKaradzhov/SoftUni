using NUnit.Framework;

namespace Skeleton
{
    [TestFixture]
    public class DummyTest
    {
        private Dummy dummy;

        [SetUp]
        public void CreateDummy()
        {
            dummy = new Dummy(100, 100);
        }

        [Test]
        public void DummyLoosesHealthIfAttacked()
        {
            dummy.TakeAttack(50);

            Assert.That(dummy.Health, Is.EqualTo(50));
        }

        [Test]
        public void TestIfDeadDummyThrowsExceptionIfAttacked()
        {
            Dummy dummy = new Dummy(2, 1);

            dummy.TakeAttack(2);

            Assert.That(() => dummy.TakeAttack(0),
                Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void TestIfDeadDummyCanGiveXP()
        {
            dummy.TakeAttack(100);

            dummy.GiveExperience();

            Assert.That(() => dummy.GiveExperience(), Is.EqualTo(100));
        }

        [Test]
        public void TestAliveDummyCannotGiveXP()
        {
            dummy.TakeAttack(99);

            Assert.That(() => dummy.GiveExperience(),
                Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }
    }
}