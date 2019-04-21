using System;
using System.Collections.Generic;
using FinChain.Models.Accounts;
using FinChain.Models.Actions;


namespace Actions
{

    public class TransferFromPersonToPersonAction : IAction
    {
        public ActionId RequirementsId { get; }
        private IActionRequirements ActionRequirements { get; }
        public bool IsActive { get; private set; }

        public List<AccountType> ExecuteOrder { get; }
        
        public TransferFromPersonToPersonAction(ActionId requirementsId)
        {
            RequirementsId = requirementsId;
            ExecuteOrder = new List<AccountType> {AccountType.Person};
            ActionRequirements = new TransferFromPersonToPersonActionRequirements();
        }
        
        public void Execute(params object[] list)
        {   
            var sender = (IAccount) list[0];
            var receiver = (IAccount) list[1];
            var amount = (uint) list[2];

            if (sender.Type != AccountType.Person || receiver.Type != AccountType.Person)
            {
                throw new ArgumentException("Incorrect params. Expected sender, receiver, amount.");
            }

            if (!IsActive)
            {
                throw new Exception("Action is not active.");
            }

            TransferFromPersonToPerson(sender, receiver, amount);
            IsActive = false;
        }
        
        private void TransferFromPersonToPerson(IAccount sender, IAccount receiver, uint amount)
        {
            if (sender.Balance < amount)
            {
                return;
            }
            
            sender.Balance -= amount;
            receiver.Balance += amount;
        }

        private void ExecuteRequirements()
        {
            var actionIds = ActionRequirements.DequeueActions();

            foreach (var id in actionIds)
            {
//                var action =
//                action.Execute(); //TODO: ???
            }
        }
    }
}