using System.Collections.Generic;
using FinChain.Models.Accounts;
using FinChain.Models.Actions;

namespace Actions
{
    public class BuyAssetAction : IAction
    {
        public KeyValuePair<Queue<AccountType>, Queue<List<IAction>>> LinksQueue { get; private set; }
        
//        public List<IAction> Links { get; }
        
        public void Execute(IAccount initiator, IAccount receiver, uint amount)
        {
            throw new System.NotImplementedException();
        }

        private void TransferFromPersonToPerson(IAccount sender, IAccount receiver, uint amount)
        {
            // transfer transaction
        }

        public IActionRequirements ActionRequirements { get; }
        public ActionId RequirementsId { get; }
        public bool IsActive { get; }

        public void Execute(params object[] list)
        {
            var sender = (IAccount) list[0];
            var receiver = (IAccount) list[1];
            var amount = (uint) list[2];

            if (sender.Type == AccountType.Person && receiver.Type == AccountType.Person)
            {
                TransferFromPersonToPerson(sender, receiver, amount);
            }
        }
    
        public void AddLink(IAction action)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveLink(IAction action)
        {
            throw new System.NotImplementedException();
        }

        public bool Equals(IAction x, IAction y)
        {
            throw new System.NotImplementedException();
        }

        public int GetHashCode(IAction obj)
        {
                throw new System.NotImplementedException();
        }
    }
}