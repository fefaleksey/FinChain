using System;
using System.Collections.Generic;
using FinChain.Models.Accounts;
using FinChain.Models.Actions;
using NotaryNode.Client;
using RuleChain.Controller;

namespace Actions
{
    public class TakeCreditAction : IAction
    {
        public ActionId Id { get; }
        public bool IsActive { get; private set; }
        public List<AccountType> AccessToDeploy { get; }

        public List<AccountType> ExecuteOrder { get; }
        private const ActionType Type = ActionType.TakeCredit;
        private readonly IRuleChainController _controller;
        private readonly INotaryNodeClient _client;

        public TakeCreditAction(IRuleChainController controller, INotaryNodeClient client)
        {
            _controller = controller;
            _client = client;
            AccessToDeploy = new List<AccountType>()
            {
                AccountType.Organization
            };
            throw new NotImplementedException();
            // TODO: Configure execute order
            ExecuteOrder = new List<AccountType> {AccountType.Person};
        }
        
        public ActionExecutionResult Execute(Account sender, params object[] list)
        {   
            throw new NotImplementedException();
        }

        public void AddRequirement(ActionType requirement, int step)
        {
            throw new NotImplementedException();
        }

        public void RemoveRequirement(int step, int position)
        {
            throw new NotImplementedException();
        }

        public IActionRequirements GetRequirements()
        {
            throw new NotImplementedException();
        }

        private void ExecuteRequirements(Account sender)
        {
            var requirements = _controller.GetRequirements(Type);
            var actionTypes = requirements.PeekActions();
            foreach (var actionType in actionTypes)
            {
                var action = _client.GetRequirement(actionType);
                action.Execute(sender);
            }
        }
    }
}