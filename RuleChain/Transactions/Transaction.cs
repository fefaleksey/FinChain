using System;

namespace RuleChain.Transactions
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
        public uint GovernBy { get; }
        public IAddress Sender { get; }
        public IAddress Receiver { get; }

        public TransactionType Type()
        {
            throw new NotImplementedException();
        }
    }
}