using System;
using System.Collections.Generic;
using FinChain.Models.Accounts;
using FinChain.Models.Actions;
using UserChain.Models;
using UserChain.Models.Enums;

namespace UserChain
{
    internal class State : IState
    {
        private readonly Dictionary<AccountAddress, Account> _accounts = new Dictionary<AccountAddress, Account>();
        private readonly Dictionary<ActionId, IAction> _actions = new Dictionary<ActionId, IAction>();

        public void UpdateState(Block block)
        {
            foreach (var transaction in block.Transactions)
            {
                ApplyTransaction(transaction);
            }
        }

        private void ApplyTransaction(UserChainTransaction transaction)
        {
            switch (transaction.Type)
            {
                case TransactionType.Deploy:
                    Deploy_Handler(transaction);
                    return;
                case TransactionType.CallContractFunction:
                    CallContractFunction_Handler(transaction);
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Deploy_Handler(UserChainTransaction transaction)
        {
            var sender = transaction.Sender;
            var action = (IAction) transaction.Params[0];
            foreach (var accountType in action.AccessToDeploy)
            {
                if (sender.Type == accountType)
                {
                    Deploy(action);
                }
            }
        }

        private void Deploy(IAction action)
        {
            _actions.Add(action.Id, action);
        }

        private void CallContractFunction_Handler(UserChainTransaction transaction)
        {
            var id = transaction.ContractToCall;
            _actions[id].Execute(transaction.Sender, transaction.Params);
        }
    }
}