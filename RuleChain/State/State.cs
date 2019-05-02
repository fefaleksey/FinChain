using System;
using System.Collections.Generic;
using FinChain.Models.Actions;
using RuleChain.Models;
using RuleChain.Models.Enums;

namespace RuleChain.State
{
    public class State : IState
    {
        private readonly List<ActionType> _actions = new List<ActionType>();

        private readonly Dictionary<ActionType, IAction> _requirements =
            new Dictionary<ActionType, IAction>();

        public IActionRequirements GetRequirements(ActionType type)
        {
            return _requirements.ContainsKey(type) ? _requirements[type].GetRequirements() : null;
        }

        public void UpdateState(RuleBlock block)
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
                case TransactionType.AddRequirement:
                {
                    AddActionToRequirements_Handler(transaction);
                    break;
                }
                case TransactionType.RemoveRequirement:
                {
                    RemoveActionFromRequirements_Handler(transaction);
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

        private void AddActionToRequirements_Handler(RuleTransaction transaction)
        {
            _requirements[transaction.Action].AddRequirement(transaction.Requirement, transaction.Step);
        }

        private void RemoveActionFromRequirements_Handler(RuleTransaction transaction)
        {
            _requirements[transaction.Action].RemoveRequirement(transaction.Step, transaction.Position);
        }

        private void AddAction_Handler(RuleTransaction transaction)
        {
            _actions.Add(transaction.Action);
        }

        private void RemoveAction_Handler(RuleTransaction transaction)
        {
            _actions.Remove(transaction.Action);
        }
    }
}