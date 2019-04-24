using System;
using System.Collections.Generic;
using FinChain.Models.Actions;
using RuleChain.Models;
using RuleChain.Models.Enums;

namespace RuleChain.State
{
    public class State : IState
    {
        private readonly Dictionary<ActionType, IActionRequirements> _requirements =
            new Dictionary<ActionType, IActionRequirements>();
        
        public List<IActionRequirements> Rules { get; } = new List<IActionRequirements>();
        
        public IActionRequirements GetRequirements(ActionType type)
        {
            return _requirements.ContainsKey(type) ? _requirements[type] : null;
        }

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
                    AddAction_Handler(transaction);
                    break;
                }
                case TransactionType.RemoveAction:
                {
                    RemoveAction_Handler(transaction);
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
            _requirements.Add(transaction.ActionTypeKey, transaction.Requirements);
        }
        
        private void AddActionToRequirement_Handler(RuleTransaction transaction)
        {
            var requirementToChange = _requirements[transaction.ActionTypeKey];
            requirementToChange.AddAction(transaction.ActionTypeValue, transaction.Step);
        }

        private void RemoveRequirements_Handler(RuleTransaction transaction)
        {
            _requirements[transaction.ActionTypeKey].Clear();
        }

        private void AddAction_Handler(RuleTransaction transaction)
        {
            _requirements.Add(transaction.ActionTypeKey, transaction.Requirements);
        }

        private void RemoveAction_Handler(RuleTransaction transaction)
        {
            _requirements.Remove(transaction.ActionTypeKey);
        }
    }
}