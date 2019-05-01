using FinChain.Models.Accounts;
using FinChain.Models.Actions;

namespace Actions
{
    public class PayTaxAction : IAction
    {
        public ActionId Id { get; } = new ActionId();
        public bool IsActive { get; } = false;
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
                case AccountType.Person:
                    return PayTax(sender);
                default:
                    return ActionExecutionResult.Failed;
            }
        }

        public void AddRequirement(ActionType requirement, int step) => ActionRequirements.AddAction(requirement, step);

        public void RemoveRequirement(int step, int position) => ActionRequirements.RemoveAction(step, position);

        public IActionRequirements GetRequirements() => ActionRequirements;

        private ActionExecutionResult ChangePercent(byte newValue)
        {
            if (newValue > 100)
            {
                return ActionExecutionResult.Failed;
            }
            Percent = newValue;
            return ActionExecutionResult.Success;
        }

        private ActionExecutionResult PayTax(Account account)
        {
            var balance = account.Balance;
            account.Balance -= (int) (balance * (double) Percent / 100);
            return ActionExecutionResult.Success;
        }
    }
}