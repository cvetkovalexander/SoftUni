using System.Collections;
using System.Collections.Generic;

namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System.Linq;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private const int Limit = 16;

        [TestCase(0), TestCase(Limit / 2), TestCase(Limit)]
        public void DataBaseShouldInitializeProperly(int n)
        {
            Person[] array = InitializeTestArray(n);

            Database database = new(array);
            Assert.That(database.Count, Is.EqualTo(n));
            AssertCorrectContent(database, array);
            //Assert.That(database.Fetch(), Is.EqualTo(array));
        }

        [Test]
        public void DataBaseInitializationShouldThrowExceptionIfLimitIsSurpasses()
        {
            Person[] array = InitializeTestArray(Limit + 1);

            Assert.Throws<ArgumentException>(() =>
            {
                var database = new Database(array);
            });
        }
        [TestCase(0), TestCase(Limit / 2)]
        public void AddMethodShouldWorkProperly(int n)
        {
            Person[] array = InitializeTestArray(n);
            Database database = new();
            for (int i = 0; i < n; i++)
            {
                database.Add(array[i]);

                Assert.That(database.Count, Is.EqualTo(i + 1));
                AssertCorrectContent(database, array.Take(i + 1));
                //Assert.That(database.Fetch(), Is.EqualTo(array.Take(i + 1)));
            }
        }

        [Test]
        public void AddShouldThrowExceptionIfUsernameIsNotUnique()
        {
            Database database = new();
            Person p1 = new(1, "test");
            Person p2 = new(2, "test");

            database.Add(p1);
            Assert.That(() => database.Add(p2), Throws.InstanceOf<InvalidOperationException>().With.Message.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void AddShouldThrowExceptionIfIdIsNotUnique()
        {
            Database database = new();
            Person p1 = new(1, "test1");
            Person p2 = new(1, "test2");

            database.Add(p1);
            Assert.That(() => database.Add(p2), Throws.InstanceOf<InvalidOperationException>());
        }

        [TestCase(""), TestCase(null)]
        public void FindByUserNameShouldThrowExceptionIfUsernameIsInvalid(string invalidArg)
        {
            Database database = new();
            Person test = new(1, "test");

            database.Add(test);
            Assert.That(() => database.FindByUsername(invalidArg), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionIfUsernameIsNotFound()
        {
            Database database = new();

            Assert.That(() => database.FindByUsername("test"), Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void FindByIdShouldThrowAnExceptionIfIdIsNotFound()
        {
            Database database = new();

            Assert.That(() => database.FindById(1), Throws.InstanceOf<InvalidOperationException>());
        }

        [TestCase(-1), TestCase(-2), TestCase(-5), TestCase(-10)]
        public void FindByIdShouldThrowAnExceptionIfIdIsInvalid(int invalidArg)
        {
            Database database = new();

            Assert.That(() => database.FindById(invalidArg), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfLimitIsSurpassed()
        {
            Person[] array = InitializeTestArray(Limit);
            Database database = new(array);

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(1000, "Invalid")));

            Assert.That(Limit, Is.EqualTo(database.Count));
            AssertCorrectContent(database, array);
        }

        [Test]
        public void RemoveMethodShouldWorkProperly()
        {
            Person[] array = InitializeTestArray(Limit);
            Database database = new(array);

            for (int i = Limit - 1; i >= 0; i--)
            {
                database.Remove();

                Assert.That(database.Count, Is.EqualTo(i));
                AssertCorrectContent(database, array.Take(i));
                //Assert.That(database.Fetch(), Is.EqualTo(array.Take(i)));
            }
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfCountIsEqualToZero()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        private Person[] InitializeTestArray(int n)
        {
            Person[] array = new Person[n];
            for (int i = 0; i < n; i++) array[i] = new Person(i + 1, $"Person #{i + 1}");
            return array;
        }

        private void AssertCorrectContent(Database database, IEnumerable<Person> expected)
        {
            Assert.That(database, Is.Not.Null);
            Assert.That(expected, Is.Not.Null);

            foreach (var person in expected)
            {
                Assert.That(person, Is.SameAs(database.FindByUsername(person.UserName)));
                Assert.That(person, Is.SameAs(database.FindById(person.Id)));
            }
        }
    }
}