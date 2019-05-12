using System;
using FinChain.Models;
using FinChain.Models.Actions;
using RuleChain.Models.Enums;

namespace RuleChain.Models
{
    public class RuleTransaction
    {
        public DateTime Time { get; }
        public TransactionStatus Status { get; set; }
        public TransactionType Type { get; }
        public ActionType Action { get; }
        public IAction Requirement { get; }
        public int Step { get; }
        public int Position { get; }

        private RuleTransaction()
        {
        }
        
        private RuleTransaction(TransactionType type, ActionType action, IAction requirement, int step, int position)
        {
            Type = type;
            Action = action;
            Requirement = requirement;
            Step = step;
            Position = position;
            Status = TransactionStatus.Created;
            Time = DateTime.UtcNow;
        }

        public static RuleTransaction CreateAddActionTransaction(ActionType action)
        {
            var transaction = new RuleTransaction(TransactionType.AddAction, action, null
                , 0, 0);
            return transaction;
        }

        public static RuleTransaction CreateRemoveActionTransaction(ActionType action)
        {
            var transaction = new RuleTransaction(TransactionType.RemoveAction, action, null, 0, 0);
            return transaction;
        }

        public static RuleTransaction CreateAddRequirementsTransaction(ActionType action, IAction requirement, int step)
        {
            var transaction = new RuleTransaction(TransactionType.AddRequirement, action, requirement, step, 0);
            return transaction;
        }

        public static RuleTransaction CreateRemoveRequirementsTransaction(ActionType action, int step, int position)
        {
            var transaction = new RuleTransaction(TransactionType.RemoveAction, action, null, step, position);
            return transaction;
        }
    }
}