using System.Collections.Generic;
using FinChain.Models.Accounts;
using FinChain.Models.Actions;
using RuleChain.Controller;


namespace Actions
{

    public class TransferFromPersonToPersonAction : IAction
    {
        public ActionId Id { get; } = new ActionId();
        public bool IsActive { get; private set; }
        public List<AccountType> ExecuteOrder { get; }

        private const ActionType _type = ActionType.TransferFromPersonToPerson;
        private IActionRequirements ActionRequirements { get; }
        private readonly IRuleChainController _controller;


        public TransferFromPersonToPersonAction(IRuleChainController controller)
        {
            _controller = controller;
            ExecuteOrder = new List<AccountType> {AccountType.Person};
            ActionRequirements = new TransferFromPersonToPersonActionRequirements();
        }
        
        public ActionExecutionResult Execute(Account sender, params object[] list)
        {   
            var receiver = (Account) list[0];
            var amount = (uint) list[1];

            if (sender.Type != AccountType.Person || receiver.Type != AccountType.Person)
            {
//                throw new ArgumentException("Incorrect params. Expected sender, receiver, amount.");
                return ActionExecutionResult.Failed;
            }

            if (!IsActive)
            {
//                throw new Exception("Action is not active.");
                return ActionExecutionResult.Failed;
            }

            TransferFromPersonToPerson(sender, receiver, amount);
            ExecuteRequirements(sender);
            IsActive = false;
            return ActionExecutionResult.Success;
        }
        
        private ActionExecutionResult TransferFromPersonToPerson(Account sender, Account receiver, uint amount)
        {
            if (sender.Balance < amount)
            {
                return ActionExecutionResult.Failed;
            }
            
            sender.Balance -= amount;
            receiver.Balance += amount;
            return ActionExecutionResult.Success;
        }

        private void ExecuteRequirements(Account sender)
        {
            var requirements = _controller.GetRequirements(_type);
            var actionTypes = requirements.PeekActions();
            var builder = new ActionBuilder(_controller);
            foreach (var actionType in actionTypes)
            {
                var action = builder.Create(actionType);
                action.Execute(sender);
            }
        }
    }
}