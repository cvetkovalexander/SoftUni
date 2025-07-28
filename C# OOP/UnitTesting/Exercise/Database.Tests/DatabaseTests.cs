using System;
using System.Linq;
using System.Net.NetworkInformation;

namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private const int Limit = 16;

        [TestCase(0), TestCase(Limit / 2), TestCase(Limit)]
        public void DataBaseShouldInitializeProperly(int n)
        {
            int[] array = InitializeTestArray(n);

            Database database = new(array);
            Assert.That(database.Count, Is.EqualTo(n));
            Assert.That(database.Fetch(), Is.EqualTo(array));
        }

        [Test]
        public void DataBaseInitializationShouldThrowExceptionIfLimitIsSurpasses()
        {
            int[] array = InitializeTestArray(Limit + 1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                var database = new Database(array);
            });
        }
        [TestCase(0), TestCase(Limit / 2)]
        public void AddMethodShouldWorkProperly(int n)
        {
            int[] array = new int[n];
            Database database = new();
            for (int i = 0; i < n; i++)
            {
                database.Add(i + 1);
                array[i] = i + 1;

                Assert.That(database.Count, Is.EqualTo(i + 1));
                Assert.That(database.Fetch(), Is.EqualTo(array.Take(i + 1)));
            }
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfLimitIsSurpassed()
        {
            int[] array = InitializeTestArray(Limit);
            Database database = new(array);

            Assert.Throws<InvalidOperationException>(() => database.Add(0));
        }

        [TestCase(Limit / 2)]
        public void RemoveMethodShouldWorkProperly(int n)
        {
            int[] array = InitializeTestArray(n);
            Database database = new(array);

            for (int i = n - 1; i >= 0; i--)
            {
                database.Remove();

                Assert.That(database.Count, Is.EqualTo(i));
                Assert.That(database.Fetch(), Is.EqualTo(array.Take(i)));
            }
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfCountIsEqualToZero()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        private int[] InitializeTestArray(int n)
        {
            int[] array = new int[n];
            for (int i = 0; i < n; i++) array[i] = i + 1;
            return array;
        }
    }
}
