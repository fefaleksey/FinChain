using System.Collections.Generic;
using FinChain.Models.Accounts;
using FinChain.Models.Actions;
using NotaryNode.Client;
using RuleChain.Controller;

namespace Actions
{
    public class TransferFromPersonToPersonAction : IAction
    {
        public ActionId Id { get; } = new ActionId();
        public bool IsActive { get; private set; }
        public List<AccountType> AccessToDeploy { get; }

        private const ActionType Type = ActionType.TransferFromPersonToPerson;
        private IActionRequirements ActionRequirements { get; }
        private readonly IRuleChainController _controller;
        private readonly INotaryNodeClient _client;


        public TransferFromPersonToPersonAction(IRuleChainController controller, INotaryNodeClient client)
        {
            _controller = controller;
            ActionRequirements = _client.GetRequirements(Type);
            _client = client;
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
            var requirements = ActionRequirements.DequeueActions();
            foreach (var requirement in requirements)
            {
                requirement.Execute(sender, list);
            }
        }
    }
}