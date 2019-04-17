using System;
using System.Collections.Generic;
using UserChain.Accounts;

namespace Actions
{

    public class TransferFromPersonToPersonAction : IAction
    {
        public Guid RequirementsId { get; }
        public IRequirements Requirements { get; }
        public bool IsActive { get; private set; }

        public List<AccountType> ExecuteOrder { get; }
        
        public TransferFromPersonToPersonAction(Guid requirementsId)
        {
            RequirementsId = requirementsId;
            ExecuteOrder = new List<AccountType> {AccountType.Person};
            Requirements = new TransferFromPersonToPersonRequirements();
        }
        
        public void Execute(params object[] list)
        {
            var sender = (IAccount) list[0];
            var receiver = (IAccount) list[1];
            var amount = (uint) list[2];

            if (sender.Type == AccountType.Person && receiver.Type == AccountType.Person)
            {
                TransferFromPersonToPerson(sender, receiver, amount);
                IsActive = false;
                return;
            }
            throw new ArgumentException("Incorrect params. Expected sender, receiver, amount.");
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
            var actions = Requirements.DequeueActions();

            foreach (var action in actions)
            {
                action.Execute(); //TODO: ???
            }
        }
    }
}