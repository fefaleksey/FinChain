using System;
using System.Collections.Generic;
using FinChain.Models.Accounts;

namespace UserChain.Transactions
{
    public class Transaction : ITransaction
    {
        public Transaction(Account sender, Account receiver)
        {
            Sender = sender;
            Receiver = receiver;
            Time = DateTime.UtcNow;
            Status = TransactionStatus.Created;

            GovernBy = new List<AccountType> {sender.Type, receiver.Type};
        }

        public DateTime Time { get; }
        public TransactionStatus Status { get; }
        public List<AccountType> GovernBy { get; }
        public Account Sender { get; }
        public Account Receiver { get; }

        public TransactionType Type()
        {
            throw new NotImplementedException();
        }
    }
}