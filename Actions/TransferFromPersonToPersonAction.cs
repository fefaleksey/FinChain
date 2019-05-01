using FinChain.Models.Accounts;
using FinChain.Models.Actions;
using RuleChain.Controller;

namespace Actions
{
    public class TransferFromPersonToPersonAction : IAction
    {
        public ActionId Id { get; } = new ActionId();
        public bool IsActive { get; private set; }

        private const ActionType Type = ActionType.TransferFromPersonToPerson;
        private IActionRequirements ActionRequirements { get; }
        private readonly IRuleChainController _controller;


        public TransferFromPersonToPersonAction(IRuleChainController controller)
        {
            _controller = controller;
            ActionRequirements = new ActionRequirements();
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
            ExecuteRequirements(sender);
            IsActive = false;
            return result;
        }

        public void AddRequirement(ActionType requirement, int step) => ActionRequirements.AddAction(requirement, step);

        public void RemoveRequirement(int step, int position) => ActionRequirements.RemoveAction(step, position);

        public IActionRequirements GetRequirements() => ActionRequirements;
        

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

        private void ExecuteRequirements(Account sender)
        {
            var requirements = _controller.GetRequirements(Type);
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