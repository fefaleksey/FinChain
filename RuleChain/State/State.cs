using System;
using System.Collections.Generic;
using FinChain.Models;
using FinChain.Models.Actions;
using RuleChain.Models;
using RuleChain.Models.Enums;

namespace RuleChain.State
{
    public class State : IState
    {
//        private readonly List<ActionType> _actions = new List<ActionType>();

        private readonly Dictionary<ActionType, IActionRequirements> _actions =
            new Dictionary<ActionType, IActionRequirements>();
        
        public IActionRequirements GetRequirements(ActionType type)
        {
            return _actions.ContainsKey(type) ? _actions[type] : null;
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
                case TransactionType.AddAction:
                    AddAction_Handler(transaction);
                    break;
                case TransactionType.RemoveAction:
                    RemoveAction_Handler(transaction);
                    break;
                case TransactionType.AddRequirement:
                    AddActionToRequirements_Handler(transaction);
                    break;
                case TransactionType.RemoveRequirement:
                    RemoveActionFromRequirements_Handler(transaction);
                    break;
                default:
                    throw new ArgumentException("transaction type handler is not implemented");
            }
        }

        private void AddAction_Handler(RuleTransaction transaction)
        {
            _actions.Add(transaction.Action, new ActionRequirements());
        }

        private void RemoveAction_Handler(RuleTransaction transaction)
        {
            _actions.Remove(transaction.Action);
        }
        
        private void AddActionToRequirements_Handler(RuleTransaction transaction)
        {
            _actions[transaction.Action].AddAction(transaction.Requirement, transaction.Step);
        }

        private void RemoveActionFromRequirements_Handler(RuleTransaction transaction)
        {
            _actions[transaction.Action].RemoveAction(transaction.Step, transaction.Position);
        }
    }
}