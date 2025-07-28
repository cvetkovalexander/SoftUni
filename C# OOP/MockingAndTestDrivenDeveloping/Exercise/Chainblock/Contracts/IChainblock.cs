using System.Collections.Generic;

namespace Chainblock.Contracts;

public interface IChainblock
{
    int Count { get; }

    void Add(ITransaction tx);

    bool Contains(int id);

    void RemoveById(int id);

    ITransaction GetById(int id);

    IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status);
    IEnumerable<ITransaction> GetAll();

    IEnumerable<ITransaction> GetBySender(string sender);

    IEnumerable<ITransaction> GetByReceiver(string receiver);

    IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount);

    IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount);

    IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi);

    IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi);
}