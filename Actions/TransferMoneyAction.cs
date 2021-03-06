using System.Collections.Generic;
using FinChain.Models.Accounts;
using FinChain.Models.Actions;

namespace Actions
{
    public class TransferMoneyAction : IAction
    {
        public ActionId Id { get; } = new ActionId();
        public bool IsActive { get; private set; }
        public List<AccountType> AccessToDeploy { get; }

        private const ActionType Type = ActionType.TransferFromPersonToPerson;
        private readonly IActionRequirements _actionRequirements;


        public TransferMoneyAction(IActionRequirements requirements)
        {
            _actionRequirements = requirements;
            AccessToDeploy = new List<AccountType>()
            {
                AccountType.Person
            };
        }

        public ActionExecutionResult Execute(Account sender, params object[] list)
        {
            var receiver = (Account) list[0];
            var amount = (int) list[1];

            if (sender.Type != AccountType.Person || receiver.Type != AccountType.Person)
            {
                return ActionExecutionResult.Failed;
            }

            if (!IsActive || amount <= 0)
            {
                return ActionExecutionResult.Failed;
            }

            var result = TransferFromPersonToPerson(sender, receiver, amount);
            ExecuteRequirements(sender, list);
            IsActive = false;
            return result;
        }

        private ActionExecutionResult TransferFromPersonToPerson(Account sender, Account receiver, int amount)
        {
            if (sender.Balance < amount)
            {
                return ActionExecutionResult.Failed;
            }

            sender.Balance -= amount;
            receiver.Balance += amount;
            return ActionExecutionResult.Success;
        }

        private void ExecuteRequirements(Account sender, params object[] list)
        {
            var requirements = _actionRequirements.DequeueActions();
            foreach (var requirement in requirements)
            {
                requirement.Execute(sender, list);
            }
        }
    }
}