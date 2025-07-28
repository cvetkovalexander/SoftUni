using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Axe axe;
        private Dummy dummy;
        private Dummy deadDummy;t
        [SetUp]
        public void SetUp()
        {
            axe = new(10, 10);
            dummy = new(20, 10);
            deadDummy = new(0, 10);
        }
        [Test]
        public void DummyLoosesHealthAfterAttacked()
        {
            axe.Attack(dummy);
            Assert.AreEqual(10, dummy.Health);
        }
        [Test]
        public void DeadDummyThrowsIfAttacked()
        {
            Assert.Throws<InvalidOperationException>(() => axe.Attack(deadDummy));
        }

        [Test]
        public void DeadDummyCanGiveXp()
        {
            Assert.AreEqual(10, deadDummy.GiveExperience());
        }

        [Test]
        public void AliveDummyThrowsIfTryToGiveXp()
        {
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}