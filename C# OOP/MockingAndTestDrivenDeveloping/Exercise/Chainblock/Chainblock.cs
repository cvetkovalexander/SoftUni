using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chainblock.Contracts;

namespace Chainblock;

public class Chainblock : IChainblock
{
    private readonly Dictionary<int, ITransaction> _transactions = new();
    public int Count => this._transactions.Count;
    public void Add(ITransaction tx)
    {
        if (tx is null) throw new ArgumentNullException(nameof(tx));
        if (this.Contains(tx.Id))
            throw new InvalidOperationException("All transactions must have unique Ids.");

        this._transactions[tx.Id] = tx;
    }

    public bool Contains(int id) => this._transactions.ContainsKey(id);

    public void RemoveById(int id)
    {
        if (!this._transactions.Remove(id)) throw new InvalidOperationException($"Transaction with id {id} was not found and could not be removed .");
    }


    public ITransaction GetById(int id)
    {
        if (!this.Contains(id)) throw new InvalidOperationException("Transaction not found.");
        return this._transactions[id];
    }

    public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        => this.InOrder(this._transactions.Values.Where(t => t.Status == status));

    public IEnumerable<ITransaction> GetAll()
        => this.InOrder(this._transactions.Values);

    public IEnumerable<ITransaction> GetBySender(string sender)
        => this.InOrder(this._transactions.Values.Where(t => t.From == sender));

    public IEnumerable<ITransaction> GetByReceiver(string receiver)
        => this.InOrder(this._transactions.Values.Where(t => t.To == receiver));

    public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
    {
        throw new NotImplementedException();
    }

    private IEnumerable<ITransaction> InOrder(IEnumerable<ITransaction> transactions)
        => transactions.OrderByDescending(t => t.Amount).ThenBy(t => t.Id);
}