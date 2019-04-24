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
        public ActionType ActionTypeKey { get; }
        public ActionType ActionTypeValue { get; }
        public IActionRequirements Requirements { get; }
        public int Step { get; }
        public int Position { get; }

        private RuleTransaction(TransactionType type, ActionType actionTypeKey, ActionType actionTypeValue
            , IActionRequirements requirements, int step, int position)
        {
            Type = type;
            ActionTypeKey = actionTypeKey;
            ActionTypeValue = actionTypeValue;
            Requirements = requirements;
            Step = step;
            Position = position;
            Status = TransactionStatus.Created;
            Time = DateTime.UtcNow;
        }
//        TODO: Add following:
//        RemoveRequirements,
//        AddActionToRequirement,
//        RemoveActionFromRequirement,

        public static RuleTransaction CreateAddActionTransaction(ActionType actionTypeKey,
            IActionRequirements requirements)
        {
            var transaction = new RuleTransaction(TransactionType.AddRequirements, actionTypeKey, ActionType.Null
                , requirements, 0, 0);
            return transaction;
        }

        public static RuleTransaction CreateRemoveActionTransaction(ActionType actionTypeKey)
        {
            var transaction = new RuleTransaction(TransactionType.AddRequirements, actionTypeKey, ActionType.Null
                , null, 0, 0);
            return transaction;
        }

        public static RuleTransaction CreateAddRequirementsTransaction(ActionType actionTypeKey,
            ActionType actionTypeValue, IActionRequirements requirements, int step)
        {
            var transaction = new RuleTransaction(TransactionType.AddRequirements, actionTypeKey,
                actionTypeValue, requirements, step, 0);
            return transaction;
        }
    }
}