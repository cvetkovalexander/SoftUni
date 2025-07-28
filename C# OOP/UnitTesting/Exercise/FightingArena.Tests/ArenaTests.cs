using System;
using NUnit.Framework.Interfaces;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void ArenaShouldBeInitializedCorrectly()
        {
            Arena arena = new();

            Assert.That(arena.Warriors, Is.Not.Null);
        }

        [TestCase(2), TestCase(6), TestCase(10)]
        public void ArenaEnrollMethodShouldWorkCorrectly(int n)
        {
            Warrior[] warriors = WarriorsInitialization(n);
            Arena arena = new();

            for (int i = 0; i < n; i++)
            {
                arena.Enroll(warriors[i]);
                Assert.That(arena.Count, Is.EqualTo(i + 1));
            }
        }

        [Test]
        public void ArenaEnrollMethodShouldThrowAnExceptionIfWarriorWithSameNameIsGiven()
        {
            Warrior first = new("Test", 30, 31);
            Warrior second = new("Test", 30, 31);
            Arena arena = new();

            arena.Enroll(first);

            Assert.That(() => arena.Enroll(second), Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void ArenaFightMethodShouldGetWarriorsCorrectly()
        {
            Arena arena = new();
            Warrior first = new("Test1", 20, 31);
            int firstHp = first.HP;
            Warrior second = new("Test2", 30, 31);
            int secondHp = second.HP;

            arena.Enroll(first);
            arena.Enroll(second);

            arena.Fight("Test1", "Test2");
            Assert.That(first.HP, Is.EqualTo(firstHp - second.Damage));
            Assert.That(second.HP, Is.EqualTo(secondHp - first.Damage));
        }

        [Test]
        public void AttackMethodShouldThrowAnExceptionIfWarriorIsNotFound()
        {
            Arena arena = new();
            Warrior first = new("Test1", 20, 31);
            int firstHp = first.HP;
            Warrior second = new("Test2", 30, 31);
            int secondHp = second.HP;

            arena.Enroll(first);
            arena.Enroll(second);

            Assert.That(() => arena.Fight("Test1", "Test3"), Throws.InstanceOf<InvalidOperationException>());
        }

        private Warrior[] WarriorsInitialization(int n)
        {
            Warrior[] warriors = new Warrior[n];
            for (int i = 0; i < n; i++)
                warriors[i] = new($"Warrior#{i + 1}", i + 30, i + 31);

            return warriors;
        }
    }
}
