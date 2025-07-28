using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collections;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Collection.Tests;

[TestFixture]
public class CollectionTests
{
    private int DefaultCapacity = 16;

    [TestCase(1), TestCase(5), TestCase(7)]
    public void CollectionShouldBeInitializedCorrectlyIfItemsLengthIsLessThanInitialCapacity(int n)
    {
        int[] array = InitializeArray(n);

        Collection<int> collection = new(array);

        Assert.That(collection.Capacity, Is.EqualTo(DefaultCapacity));
        Assert.That(collection.Count, Is.EqualTo(array.Length));

    }

    [TestCase(9), TestCase(12), TestCase(16)]
    public void CollectionShouldBeInitializedCorrectlyIfItemsLengthIsMoreThanInitialCapacity(int n)
    {
        int[] array = InitializeArray(n);

        Collection<int> collection = new(array);

        Assert.That(collection.Capacity, Is.EqualTo(array.Length * 2));
        Assert.That(collection.Count, Is.EqualTo(array.Length));
    }

    [TestCase(4), TestCase(8), TestCase(10)]
    public void AddMethodShouldWorkProperly(int n)
    {
        Collection<int> collection = new Collection<int>();

        for (int i = 0; i < n; i++)
        {
            collection.Add(i + 1);
            Assert.That(collection[i], Is.EqualTo(i + 1));
            Assert.That(collection.Count, Is.EqualTo(i + 1));
        }
    }

    [TestCase(1), TestCase(5), TestCase(10)]
    public void AddRangeShouldWorkCorrectly(int n)
    {
        int[] array = InitializeArray(n);

        Collection<int> first = new(array);
        Collection<int> second = new(array);
        int start = first.Count;

        first.AddRange(array);
        foreach (int i in array)
            second.Add(i);

        for (int i = start; i < first.Count - 1; i++)
        {
            Assert.That(first[i], Is.EqualTo(second[i]));
        }
    }

    [TestCase(16), TestCase(32), TestCase(64)]
    public void EnsureMethodShouldWorkCorrectly(int n)
    {
        Collection<int> collection = new();
        for (int i = 0; i <= n; i++)
        {
            collection.Add(i + 1);
        }

        Assert.That(collection.Capacity, Is.EqualTo(n * 2));
    }

    [TestCase(2), TestCase(4), TestCase(8)]
    public void IndexerShouldWorkCorrectly(int n)
    {
        Collection<int> collection = new(InitializeArray(n));
        for (int i = 0; i < n; i++)
        {
            Assert.That(collection[i], Is.EqualTo(i + 1));
        }

        int num = 5;
        for (int i = 0; i < n; i++)
        {
            collection[i] = num;
            Assert.That(collection[i], Is.EqualTo(num));
        }

    }

    [TestCase(2), TestCase(4), TestCase(8)]
    public void IndexerShouldThrowAnExceptionOfInvalidIndexIsGiven(int n)
    {
        Collection<int> collection = new(InitializeArray(n));
        Assert.That(() => collection[n], Throws.InstanceOf<ArgumentOutOfRangeException>());
        Assert.That(() => collection[-1], Throws.InstanceOf<ArgumentOutOfRangeException>());

        Assert.That(() => collection[n] = 4, Throws.InstanceOf<ArgumentOutOfRangeException>());
        Assert.That(() => collection[-1] = 4, Throws.InstanceOf<ArgumentOutOfRangeException>());
    }

    [TestCase(2), TestCase(4), TestCase(8)]
    public void InsertAtMethodShouldWorkProperly(int n)
    {
        int[] array = InitializeArray(n);
        Collection<int> collection = new(array);

        int num = n + 1;
        collection.InsertAt(0, num);
        Assert.That(collection[0], Is.EqualTo(num));

        for (int i = 0; i < array.Length; i++)
        {
            Assert.That(collection[i + 1], Is.EqualTo(array[i]));
        }
    }

    [TestCase(2), TestCase(4), TestCase(8)]
    public void ClearMethodShouldWorkCorrectly(int n)
    {
        Collection<int> collection = new(InitializeArray(n));
        collection.Clear();
        Assert.That(collection.Count, Is.Zero);
    }

    [TestCase(2, 4), TestCase(4, 6), TestCase(8, 10)]
    public void ExchangeMethodShouldWorkCorrectly(int f, int s)
    {
        Collection<int> collection = new(InitializeArray(f + s));

        int[] temps = { collection[f], collection[s] };
        collection.Exchange(f, s);

        Assert.That(collection[f], Is.EqualTo(temps[1]));
        Assert.That(collection[s], Is.EqualTo(temps[0]));
    }

    [TestCase(2), TestCase(4), TestCase(8)]
    public void RemoveAtMethodShouldWorkCorrectly(int n)
    {
        int[] array = InitializeArray(n);
        Collection<int> collection = new(array);

        collection.RemoveAt(0);
        for (int i = 0; i < array.Length - 1; i++)
        {
            Assert.That(collection[i], Is.EqualTo(array[i + 1]));
        }
    }

    [TestCase(2), TestCase(4), TestCase(8)]
    public void ToStringMethodShouldReturnCorrectResult(int n)
    {
        int[] array = InitializeArray(n);
        Collection<int> collection = new(array);

        string collectionMessage = collection.ToString();
        string arrayMessage = $"[{string.Join(", ", array)}]";

        Assert.That(collectionMessage, Is.EqualTo(arrayMessage));
    }

    private int[] InitializeArray(int n)
    {
        int[] array = new int[n];
        for (int i = 0; i < n; i++)
            array[i] = i + 1;

        return array;
    }

}