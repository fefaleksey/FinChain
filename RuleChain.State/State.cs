using System;
using System.Collections.Generic;
using FinChain.Models.Actions;
using RuleChain.Models;
using RuleChain.Models.Enums;

namespace RuleChain.State
{
    public class State : IState
    {
        private readonly Dictionary<RequirementId, IActionRequirements> _requirements =
            new Dictionary<RequirementId, IActionRequirements>();
        
        private readonly Dictionary<ActionId, IAction> _actions = new Dictionary<ActionId, IAction>();
        
        public List<IActionRequirements> Rules { get; } = new List<IActionRequirements>();
        
        public void UpdateState(IBlock block)
        {
            foreach (var transaction in block.Transactions)
            {
                ApplyTransaction(transaction);
            }
        }

        private void ApplyTransaction(RuleTransaction transaction)
        {
            if (transaction.Status != TransactionStatus.Valid)
            {
                return;
            }
            switch (transaction.Type)
            {
                case TransactionType.AddRequirements:
                {
                    AddRequirements_Handler(transaction);
                    break;
                }
                case TransactionType.RemoveRequirements:
                {
                    RemoveRequirements_Handler(transaction);
                    break;
                }
                case TransactionType.AddActionToRequirement:
                {
                    AddActionToRequirement_Handler(transaction);
                    break;
                }
                case TransactionType.RemoveActionFromRequirement:
                {
                    throw new NotImplementedException();
                    break;
                }
                case TransactionType.AddAction:
                {
                    throw new NotImplementedException();
                    break;
                }
                case TransactionType.RemoveAction:
                {
                    throw new NotImplementedException();
                    break;
                }
                default:
                {
                    throw new ArgumentException("transaction type handler is not implemented");
                }
            }
        }

        private void AddRequirements_Handler(RuleTransaction transaction)
        {
            _requirements.Add(transaction.RequirementId, transaction.Requirements);
        }
        
        private void AddActionToRequirement_Handler(RuleTransaction transaction)
        {
            var requirementToChange = _requirements[transaction.RequirementId];
            requirementToChange.AddAction(transaction.Action, transaction.Step);
        }

        private void RemoveRequirements_Handler(RuleTransaction transaction)
        {
            _requirements.Remove(transaction.RequirementId);
        }

        public IActionRequirements GetRequirement(RequirementId requirementId)
        {
            return _requirements[requirementId];
        }

        public List<IActionRequirements> GetAllRequirements()
        {
            throw new NotImplementedException();
        }
    }
}