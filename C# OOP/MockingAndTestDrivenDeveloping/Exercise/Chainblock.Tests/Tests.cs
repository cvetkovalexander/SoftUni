using System;
using System.Collections.Generic;
using System.Linq;
using Chainblock.Contracts;
using Moq;
using NUnit.Framework;

namespace Chainblock.Tests;

public class Tests
{
    private const int DefaultPeriod = 3;
    private Chainblock _chainblock;
    private int _nextId;

    [SetUp]
    public void SetUp()
    {
        this._chainblock = new();
        this._nextId = 1;
    }

    [Test]
    public void InitialStateShouldBeCorrect()
    {
        Assert.That(this._chainblock, Has.Count.Zero);
    }

    [TestCase(1), TestCase(5), TestCase(10)]
    public void AddAndGetByMethodsShouldWorkCorrectly(int n)
    {
        ITransaction[] transactions = this.CreateTransactions(n);

        for (int i = 0; i < n; i++)
        {
            this._chainblock.Add(transactions[i]);
            Assert.That(this._chainblock, Has.Count.EqualTo(i + 1));
        }

        for (int i = 0; i < n; i++)
        {
            ITransaction actual = this._chainblock.GetById(transactions[i].Id);
            Assert.That(actual, Is.SameAs(transactions[i]));
        }
    }

    [Test]
    public void AddMethodShouldThrowAnExceptionIfInvalidArgumentsArePassed()
    {
        Assert.That(() => this._chainblock.Add(null), Throws.ArgumentNullException);
    }

    [Test]
    public void AddMethodShouldThrowAnExceptionIfTransactionIdIsNotUnique()
    {
        ITransaction first = CreateTransaction();
        ITransaction second = CreateTransaction(id: first.Id);

        this._chainblock.Add(first);

        Assert.That(() => this._chainblock.Add(second), Throws.InvalidOperationException.With.Message.Length.GreaterThan(0));
    }
    [TestCase(0), TestCase(5), TestCase(10)]
    public void GetByIdShouldThrowAnExceptionIfTransactionIsNotFound(int n)
    {
        ITransaction[] transactions = this.CreateTransactions(n);
        
        this.AddTransactions(transactions);

        Assert.That(() => this._chainblock.GetById(this._nextId), Throws.InvalidOperationException.With.Message.Length.GreaterThan(0));
    }

    [TestCase(0), TestCase(1), TestCase(10)]
    public void ContainsMethodShouldWorkCorrectly(int n)
    {
        ITransaction[] transactions = this.CreateTransactions(n);

        this.AddTransactions(transactions);

        for (int i = 0; i < n; i++)
        {
            Assert.That(this._chainblock.Contains(transactions[i].Id), Is.True);
        }
        Assert.That(this._chainblock.Contains(this._nextId), Is.False);
    }

    [TestCase(1), TestCase(5), TestCase(10)]
    public void RemoveTransactionByIdShouldWorkCorrectly(int n)
    {
        ITransaction[] transactions = this.CreateTransactions(n);
        
        this.AddTransactions(transactions);

        for (int i = 0; i < n; i++)
        {
            this._chainblock.RemoveById(transactions[i].Id);
            Assert.That(this._chainblock.Contains(transactions[i].Id), Is.False);
            Assert.That(this._chainblock, Has.Count.EqualTo(n - (i + 1)));
        }
    }

    [TestCase(0), TestCase(1), TestCase(10)]
    public void RemoveTransactionByIdShouldThrowAnExceptionIfTransactionIsNotFound(int n)
    {
        ITransaction[] transactions = this.CreateTransactions(n);
        
        this.AddTransactions(transactions);

        Assert.That(() => this._chainblock.RemoveById(this._nextId), Throws.InvalidOperationException.With.Message.Length.GreaterThan(0));
    }

    [TestCase(0, 0, 5, 6), TestCase(5, 6, 0, 0), TestCase(0, 0, 0, 0), TestCase(10, 10, 10, 10), TestCase(100, 100, 100, 100)]
    public void GetByTransactionStatusShouldWorkCorrectly(int failed, int successful, int aborted, int unauthorised)
    {
        Func<int, double> amountGenerator = PeriodicalAmount(DefaultPeriod);
        Dictionary<TransactionStatus, ITransaction[]> transactionsByStatus = new()
        {
            [TransactionStatus.Failed] = this.CreateTransactions(failed, status: _ => TransactionStatus.Failed, amount: amountGenerator),
            [TransactionStatus.Successfull] = this.CreateTransactions(successful, status: _ => TransactionStatus.Successfull, amount: amountGenerator),
            [TransactionStatus.Aborted] = this.CreateTransactions(aborted, status: _ => TransactionStatus.Aborted, amount: amountGenerator),
            [TransactionStatus.Unauthorised] = this.CreateTransactions(unauthorised, status: _ => TransactionStatus.Unauthorised, amount: amountGenerator),
        };

        this.AddTransactions(transactionsByStatus.SelectMany(x => x.Value));

        foreach (var (status, transactions) in transactionsByStatus)
        {
            IEnumerable<ITransaction> expected = ReorderPeriodically(transactions, DefaultPeriod);

            IEnumerable<ITransaction> result = this._chainblock.GetByTransactionStatus(status);   
            Assert.That(result, Is.EqualTo(expected));
        }
    }

    [TestCase(0), TestCase(1), TestCase(1000)]
    public void GetAllShouldWorkCorrectly(int n)
    {
        Func<int, TransactionStatus?> statusGenerator = PeriodicalStatus();
        Func<int, double> amountGenerator = PeriodicalAmount(DefaultPeriod);

        ITransaction[] transactions = this.CreateTransactions(n, status: statusGenerator, amount: amountGenerator);
        this.AddTransactions(transactions);

        IEnumerable<ITransaction> expected = ReorderPeriodically(transactions, DefaultPeriod);
        IEnumerable<ITransaction> result = this._chainblock.GetAll();
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(100), TestCase(1000)]
    public void GetBySenderShouldWorkCorrectly(int n)
    {
        Func<int, string> senderGenerator = PeriodicalSender(DefaultPeriod * 5);
        Func<int, double> amountGenerator = PeriodicalAmount(DefaultPeriod);

        Dictionary<string, List<ITransaction>> transactionBySender = new();
        ITransaction[] allTransactions = CreateTransactions(n, from: senderGenerator, amount: amountGenerator);

        foreach (ITransaction transaction in allTransactions)
        {
            if (!transactionBySender.ContainsKey(transaction.From))
                transactionBySender[transaction.From] = new();
            transactionBySender[transaction.From].Add(transaction);
        }

        this.AddTransactions(allTransactions);

        foreach (var (sender, transactions) in transactionBySender)
        {
            IEnumerable<ITransaction> expected = ReorderPeriodically(transactions, DefaultPeriod);
            IEnumerable<ITransaction> result = this._chainblock.GetBySender(sender);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
    [TestCase(0), TestCase(100)]
    public void GetBySenderShouldReturnEmptyCollectionIfSenderHasNoOutgoingTransactions(int n)
    {
        ITransaction[] transactions = this.CreateTransactions(n);
        this.AddTransactions(transactions);

        Assert.That(this._chainblock.GetBySender("non_existent"), Is.Empty);
    }

    [TestCase(100), TestCase(1000)]
    public void GetByReceiverShouldWorkCorrectly(int n)
    {
        Func<int, string> receiverGenerator = PeriodicalReceiver(DefaultPeriod * 5);
        Func<int, double> amountGenerator = PeriodicalAmount(DefaultPeriod);

        Dictionary<string, List<ITransaction>> transactionsByReceiver = new();
        ITransaction[] allTransactions = this.CreateTransactions(n, to: receiverGenerator, amount: amountGenerator);

        foreach (ITransaction transaction in allTransactions)
        {
            if (!transactionsByReceiver.ContainsKey(transaction.To))
                transactionsByReceiver[transaction.To] = new();
            transactionsByReceiver[transaction.To].Add(transaction);
        }

        this.AddTransactions(allTransactions);

        foreach (var (receiver, transactions) in transactionsByReceiver)
        {
            IEnumerable<ITransaction> expected = ReorderPeriodically(transactions, DefaultPeriod);
            IEnumerable<ITransaction> result = this._chainblock.GetByReceiver(receiver);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
    [TestCase(0), TestCase(100)]
    public void GetByReceiverShouldReturnEmptyCollectionIfSenderHasNoOutgoingTransactions(int n)
    {
        ITransaction[] transactions = this.CreateTransactions(n);
        this.AddTransactions(transactions);

        Assert.That(this._chainblock.GetByReceiver("non_existent"), Is.Empty);
    }

    private ITransaction CreateTransaction(int? id = null, TransactionStatus? status = null, string from = null, string to = null, double? amount = null)
    {
        Mock<ITransaction> mock = new Mock<ITransaction>();

        int actualId = id ?? this._nextId++;

        mock.SetupGet(t => t.Id).Returns(actualId);
        mock.SetupGet(t => t.Status).Returns(status.GetValueOrDefault(TransactionStatus.Successfull));
        mock.SetupGet(t => t.From).Returns(from ?? "A");
        mock.SetupGet(t => t.To).Returns(to ?? "B");
        mock.SetupGet(t => t.Amount).Returns(amount.GetValueOrDefault(3.14));

        return mock.Object;
    }

    private void AddTransactions(IEnumerable<ITransaction> transactions)
    {
        foreach (var transaction in transactions)
            this._chainblock.Add(transaction);
    }

    private ITransaction[] CreateTransactions(int n, Func<int, TransactionStatus?> status = null, Func<int, string> from = null, Func<int, string> to = null, Func<int, double> amount = null)
    {
        ITransaction[] transactions = new ITransaction[n];
        for (int i = 0; i < n; i++) transactions[i] = this.CreateTransaction(id: null, status?.Invoke(i), from?.Invoke(i), to?.Invoke(i), amount?.Invoke(i));

        return transactions;
    }

    private static Func<int, double> PeriodicalAmount(int period) => i => 1 + i % period;

    private static Func<int, TransactionStatus?> PeriodicalStatus()
    {
        TransactionStatus[] allStatuses = Enum.GetValues<TransactionStatus>();
        return i => allStatuses[i % allStatuses.Length];
    }

    private static Func<int, string> PeriodicalSender(int repeatingFactor)
        => PeriodicalString("S", repeatingFactor);

    private static Func<int, string> PeriodicalReceiver(int repeatingFactor)
        => PeriodicalString("R", repeatingFactor);

    private static Func<int, string> PeriodicalString(string prefix, int repeatingFactor)
    {
        return i => $"{prefix}-{(char)('A' + (i / repeatingFactor) % 26)}";
    }

    private static IEnumerable<ITransaction> ReorderPeriodically(IEnumerable<ITransaction> transactions, int period)
    {
        ITransaction[][] chunked = transactions.Chunk(period).ToArray();

        for (int i = 2; i >= 0; i--)
        {
            for (int j = 0; j < chunked.Length; j++)
            {
                if (i >= chunked[j].Length) break;

                yield return chunked[j][i];
            }
        }
    }
}