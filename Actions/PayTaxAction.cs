using System;
using System.Collections.Generic;
using FinChain.Models.Accounts;
using FinChain.Models.Actions;

namespace Actions
{
    public class PayTaxAction : IAction
    {
        public ActionId Id { get; } = new ActionId();
        public bool IsActive { get; } = false;
        public List<AccountType> AccessToDeploy { get; } = new List<AccountType>();
        public byte Percent { get; private set; }
        private IActionRequirements ActionRequirements { get; } = new ActionRequirements();

        public ActionExecutionResult Execute(Account sender, params object[] list)
        {
            switch (sender.Type)
            {
                case AccountType.Government when list.Length == 0:
                    return ActionExecutionResult.Failed;
                case AccountType.Government:
                {
                    var newPercent = (byte) list[0];
                    return ChangePercent(newPercent);
                }
                case AccountType.Person when list.Length == 0:
                    return ActionExecutionResult.Failed;
                case AccountType.Person:
                {
                    try
                    {
                        var amount = (int) list[1];
                        return PayTax(sender, amount);
                    }
                    catch (Exception)
                    {
                        return ActionExecutionResult.Failed;
                    }
                }
                default:
                    return ActionExecutionResult.Failed;
            }
        }

        private ActionExecutionResult ChangePercent(byte newValue)
        {
            if (newValue > 100)
            {
                return ActionExecutionResult.Failed;
            }
            Percent = newValue;
            return ActionExecutionResult.Success;
        }

        private ActionExecutionResult PayTax(Account account, int amount)
        {
            account.Balance -= (int) (amount * (double) Percent / 100);
            return ActionExecutionResult.Success;
        }
    }
}