using System;
using System.Collections.Generic;

namespace UserChain.Transactions
{
    public class Transaction : ITransaction
    {
        public Transaction(IAddress sender, IAddress receiver)
        {
            Sender = sender;
            Receiver = receiver;
            Time = DateTime.UtcNow;
            Status = TransactionStatus.Created;
        }

        public DateTime Time { get; }
        public TransactionStatus Status { get; }
        public List<UserType> GovernBy { get; }
        public IAddress Sender { get; }
        public IAddress Receiver { get; }

        public TransactionType Type()
        {
            throw new NotImplementedException();
        }
    }
}