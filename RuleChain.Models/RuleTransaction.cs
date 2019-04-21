using System;
using FinChain.Models.Actions;
using RuleChain.Models.Enums;

namespace RuleChain.Models
{
    public class RuleTransaction
    {
        public DateTime Time { get; }
        public TransactionStatus Status { get; set; }
        public TransactionType Type { get; }
        public ActionId Id { get; }
        public int Step { get; }
        public int Position { get; }

        public RuleTransaction(ActionId id, int step, int position, TransactionType type)
        {
            Id = id;
            Step = step;
            Position = position;
            Type = type;
            Status = TransactionStatus.Created;
            Time = DateTime.UtcNow;
        }
    }
}