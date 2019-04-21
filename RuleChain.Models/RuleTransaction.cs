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
        public ActionId ActionId { get; }
        public RequirementId RequirementId { get; }
        public IAction Action { get; }
        public IActionRequirements Requirements { get; }
        public int Step { get; }
        public int Position { get; }

        public RuleTransaction(TransactionType type, ActionId actionId, RequirementId requirementId, IAction action, 
            IActionRequirements requirements, int step, int position)
        {
            Type = type;
            ActionId = actionId;
            RequirementId = requirementId;
            Action = action;
            Requirements = requirements;
            Step = step;
            Position = position;
            Status = TransactionStatus.Created;
            Time = DateTime.UtcNow;
        }
    }
}