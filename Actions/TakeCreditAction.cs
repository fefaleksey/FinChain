using System;
using System.Collections.Generic;
using FinChain.Models.Accounts;
using FinChain.Models.Actions;

namespace Actions
{
    public class TakeCreditAction : IAction
    {
        public ActionId Id { get; }
        public bool IsActive { get; private set; }
        public List<AccountType> AccessToDeploy { get; }

        public List<AccountType> ExecuteOrder { get; }
        private const ActionType Type = ActionType.TakeCredit;
        private IActionRequirements ActionRequirements { get; }

        public TakeCreditAction()
        {
            throw new NotImplementedException();
        }

        public ActionExecutionResult Execute(Account sender, params object[] list)
        {
            throw new NotImplementedException();
        }

        private void ExecuteRequirements(Account sender, params object[] list)
        {
            var requirements = ActionRequirements.DequeueActions();
            foreach (var requirement in requirements)
            {
                requirement.Execute(sender, list);
            }
        }
    }
}