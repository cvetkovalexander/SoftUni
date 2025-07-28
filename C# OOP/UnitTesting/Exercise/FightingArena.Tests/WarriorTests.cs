using System;
using System.Text;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void WarriorShouldBeInitializedCorrectly()
        {
            string name = "Test";
            int damage = 1;
            int hp = 1;

            Warrior warrior = new(name, damage, hp);

            Assert.That(name, Is.EqualTo(warrior.Name));
            Assert.That(damage, Is.EqualTo(warrior.Damage));
            Assert.That(hp, Is.EqualTo(warrior.HP));
        }

        [TestCase(null), TestCase(" ")]
        public void WarriorNamePropertyShouldThrowAnExceptionIfGivenInvalidValue(string invalidArg)
        {
            Assert.That(() => new Warrior(invalidArg, 1, 1), Throws.InstanceOf<ArgumentException>());
        }
        [TestCase(0), TestCase(-1), TestCase(-10)]
        public void WarriorDamagePropertyShouldThrowAnExceptionIfGivenInvalidValue(int invalidArg)
        {
            Assert.That(() => new Warrior("Test", invalidArg, 1), Throws.InstanceOf<ArgumentException>());
        }

        [TestCase(-1), TestCase(-5), TestCase(-10)]
        public void WarriorHpPropertyShouldThrowAnExceptionIfGivenInvalidValue(int invalidArg)
        {
            Assert.That(() => new Warrior("Test", 1, invalidArg), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void WarriorAttackMethodShouldWorkCorrectlyIfEnemyHpIsBiggerThanMainDamage()
        {
            Warrior main = new("MainWarrior", 30, 40);
            int mainHp = main.HP;
            Warrior enemy = new("EnemyWarrior", 20, 35);
            int enemyHp = enemy.HP;

            main.Attack(enemy);

            Assert.That(main.HP, Is.EqualTo(mainHp - enemy.Damage));
            Assert.That(enemy.HP, Is.EqualTo(enemyHp - main.Damage));
        }

        [Test]
        public void WarriorAttackMethodShouldWorkCorrectlyIfEnemyHpIsLessThanMainDamage()
        {
            Warrior main = new("MainWarrior", 35, 40);
            int mainHp = main.HP;
            Warrior enemy = new("EnemyWarrior", 20, 32);
            int enemyHp = enemy.HP;

            main.Attack(enemy);

            Assert.That(main.HP, Is.EqualTo(mainHp - enemy.Damage));
            Assert.That(enemy.HP, Is.Zero);
        }

        [Test]
        public void WarriorAttackMethodShouldThrowAnExceptionIfMainHpIsLessThanMinAllowedHp()
        {
            Warrior main = new("MainWarrior", 35, 29);
            Warrior enemy = new("EnemyWarrior", 20, 32);

            Assert.That(() => main.Attack(enemy), Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void WarriorAttackMethodShouldThrowAnExceptionIfEnemyHpIsLessThanMinAllowedHp()
        {
            Warrior main = new("MainWarrior", 35, 31);
            Warrior enemy = new("EnemyWarrior", 20, 29);

            Assert.That(() => main.Attack(enemy), Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void WarriorAttackMethodShouldThrowAnExceptionIfMainHpIsLessThanEnemyDamage()
        {
            Warrior main = new("MainWarrior", 35, 31);
            Warrior enemy = new("EnemyWarrior", 40, 31);

            Assert.That(() => main.Attack(enemy), Throws.InstanceOf<InvalidOperationException>());
        }
    }
}