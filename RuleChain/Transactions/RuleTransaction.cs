using System;
using System.Collections.Generic;
using RuleChain.Rules;
using RuleChain.Transactions.Enums;
using UserChain.Accounts;

namespace RuleChain.Transactions
{
    public class RuleTransaction : IRuleTransaction
    {
        public DateTime Time { get; }
        public TransactionStatus Status { get; set; }
        public TransactionType Type { get; }
        public Guid ActionId { get; }
        public int Step { get; }
        public int Position { get; }

        public RuleTransaction(Guid actionId, int step, int position, TransactionType type)
        {
            ActionId = actionId;
            Step = step;
            Position = position;
            Type = type;
            Status = TransactionStatus.Created;
            Time = DateTime.UtcNow;
        }
        
        public void Apply(IVisitor visitor)
        {
            throw new NotImplementedException();
        }
    }

    interface IRuleTransaction
    {
        DateTime Time { get; }
        TransactionStatus Status { get; set; }
        Guid ActionId { get; }
        int Step { get; }
        int Position { get; }

        void Apply(IVisitor visitor);
    }

    interface IVisitor
    {
        void Apply(RuleTransaction transaction);
    }

    class RuleTransactionVisitor : IVisitor
    {
        public void Apply(RuleTransaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}