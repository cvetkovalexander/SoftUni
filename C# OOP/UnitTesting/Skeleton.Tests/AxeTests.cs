using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;
        [SetUp]
        public void SetUp()
        {
            axe = new(10, 10);
            dummy = new(int.MaxValue, 10);
        }

        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            axe.Attack(dummy);
            Assert.AreEqual(axe.DurabilityPoints, 9);
        }

        [Test]
        public void BrokenAttackCannotAttack()
        {
            for (int i = 0; i < 10; i++)
                axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }
    }
}