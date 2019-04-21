using System;
using System.Collections.Generic;
using FinChain.Models.Actions;
using RuleChain.Models;
using RuleChain.Models.Enums;

namespace RuleChain.State
{
    public class State : IState
    {
        private readonly Dictionary<ActionId, IActionRequirements> _requirements = new Dictionary<ActionId, IActionRequirements>();
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
                    AddRequirementsHandler(transaction);
                    break;
                }
                case TransactionType.RemoveRequirements:
                {
                    RemoveRequirementsHandler(transaction);
                    break;
                }
                default:
                {
                    throw new ArgumentException("transaction type handler is not implemented");
                }
            }
        }

        void AddRequirementsHandler(RuleTransaction transaction)
        {
            var requirementToChange = _requirements[transaction.Id];
            requirementToChange.AddAction(transaction.Id, transaction.Step);
        }

        void RemoveRequirementsHandler(RuleTransaction transaction)
        {
            throw new NotImplementedException();
        }
        public IActionRequirements GetRequirement(ActionId requirementId)
        {
            return _requirements[requirementId];
        }


        public List<IActionRequirements> GetAllRequirements()
        {
            throw new NotImplementedException();
        }
    }
}