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
    }
}