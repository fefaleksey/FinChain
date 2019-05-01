using System;
using FinChain.Models.Accounts;
using FinChain.Models.Actions;

namespace UserChain.Transactions
{
    public class UserChainTransaction
    {
        public DateTime Time { get; }
        public TransactionStatus Status { get; }
        public Account Sender { get; }
        public object[] Params { get; }

        public ActionId ContractToCall { get; }

        public TransactionType Type { get; }

        public UserChainTransaction(Account sender, ActionId contractToCall, TransactionType type,
            params object[] @params)
        {
            Sender = sender;
            ContractToCall = contractToCall;
            Type = type;
            Params = @params;
            Time = DateTime.UtcNow;
            Status = TransactionStatus.Created;
        }
    }
}