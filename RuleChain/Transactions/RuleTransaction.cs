using System;
using System.Collections.Generic;
using RuleChain.Rules;
using RuleChain.Transactions.Enums;
using UserChain.Accounts;

namespace RuleChain.Transactions
{
    public class RuleTransaction
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
    }
}