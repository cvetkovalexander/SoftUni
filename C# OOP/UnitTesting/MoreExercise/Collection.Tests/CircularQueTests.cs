using Collections;
using NUnit.Framework;

namespace Collection.Tests;

[TestFixture]
public class CircularQueTests
{
    private CircularQueue<string> testQueue;
    private int DefaultQueueCapacity = 8;

    [SetUp]
    public void SetUp()
    {
        testQueue = new();
    }
    [Test]
    public void CircularQueueShouldBeInitializedProperly()
    {
        Assert.That(testQueue.StartIndex, Is.Zero);
        Assert.That(testQueue.EndIndex, Is.Zero);
        Assert.That(testQueue.Capacity, Is.EqualTo(8));
        Assert.That(testQueue.Count, Is.EqualTo(0));
    }

    [TestCase(1), TestCase(5), TestCase(8)]
    public void EnqueueMethodShouldWorkProperly(int n)
    {
        for (int i = 0; i < n; i++)
        {
            testQueue.Enqueue($"TestItem#{i + 1}");
            Assert.That(testQueue.EndIndex, Is.EqualTo((i + 1) % testQueue.Capacity));
            Assert.That(testQueue.Count, Is.EqualTo(i + 1));
        }
    }
    [TestCase(1), TestCase(2), TestCase(4), TestCase(8)]
    public void EnqueueMethodShouldRunGrowMethodIfNeeded(int n)
    {
        //int end = DefaultQueueCapacity * n;
        //for (int i = 0; i <= end; i++)
        //{
        //    testQueue.Enqueue($"#{i}");
        //}

        TestQueueInitialization(DefaultQueueCapacity * n + 1);

        Assert.That(testQueue.Capacity, Is.EqualTo(DefaultQueueCapacity * (n + n)));
    }
    [TestCase(1), TestCase(2), TestCase(5)]
    public void DequeueMethodShouldWorkProperly(int n)
    {
        for (int i = 0; i < 8; i++)
            testQueue.Enqueue($"#{i + 1}");

        for (int i = 0; i < n; i++)
        {
            int countBeforeDequeue = testQueue.Count;
            testQueue.Dequeue();
            Assert.That(testQueue.StartIndex, Is.EqualTo((i + 1) % testQueue.Capacity));
            Assert.That(testQueue.Count, Is.EqualTo(countBeforeDequeue - 1));
        }
    }

    [Test]
    public void DequeueMethodShouldThrowAnExceptionIfCountIsZero()
    {
        Assert.That(() => testQueue.Dequeue(), Throws.InstanceOf<InvalidOperationException>());
    }

    [TestCase(1), TestCase(3), TestCase(5)]
    public void PeekMethodShouldWorkProperly(int n)
    {
        TestQueueInitialization(n);

        for (int i = 0; i < n; i++)
        {
            Assert.That(testQueue.Peek(), Is.EqualTo(testQueue.Dequeue()));
        }
    }

    [Test]
    public void PeekMethodShouldThrowAnExceptionIfCountIsZero()
    {
        Assert.That(() => testQueue.Peek(), Throws.InstanceOf<InvalidOperationException>());
    }

    [TestCase(1), TestCase(3), TestCase(5)]
    public void ToArrayMethodShouldWorkProperly(int n)
    {
        TestQueueInitialization(n);

        string[] resultArray = new string[testQueue.Count];
        string[] testArray = testQueue.ToArray();
        int end = testQueue.Count;

        for (int i = 0; i < end; i++)
            resultArray[i] = testQueue.Dequeue();

        Assert.That(testArray, Is.EqualTo(resultArray));
    }

    [TestCase(0), TestCase(1), TestCase(4)]
    public void ToStringMethodShouldWorkProperly(int n)
    {
        TestQueueInitialization(n);

        string[] testArray = testQueue.ToArray();
        string testMessage = "[" + string.Join(", ", testArray) + "]";
        //string resultMessage = testQueue.ToString();

        Assert.That(testQueue.ToString(), Is.EqualTo(testMessage));
    }

    private void TestQueueInitialization(int n)
    {
        for (int i = 0; i < n; i++)
            testQueue.Enqueue($"#{i + 1}");
    }
}