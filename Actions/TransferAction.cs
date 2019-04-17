using System.Collections.Generic;
using UserChain.Accounts;

namespace Actions
{
    public class TransferAction //: IAction
    {
        private IAccount _owner;
        public KeyValuePair<Queue<AccountType>, Queue<List<IAction>>> LinksQueue { get; private set; }

//        public List<IAction> Links { get; } = new List<IAction>();

        private void AccountTypesInit()
        {
            var queuePeople = new Queue<AccountType>();
            queuePeople.Enqueue(AccountType.Person);
            queuePeople.Enqueue(AccountType.Person);
//            Links.Add(queuePeople, new Queue<List<IAction>>());

            var queuePersonToOrganization = new Queue<AccountType>();
            queuePeople.Enqueue(AccountType.Person);
            queuePeople.Enqueue(AccountType.Organization);
//            Links.Add(queuePersonToOrganization, new Queue<List<IAction>>());

            var queueOrganizationToPerson = new Queue<AccountType>();
            queuePeople.Enqueue(AccountType.Organization);
            queuePeople.Enqueue(AccountType.Person);
//            Links.Add(queueOrganizationToPerson, new Queue<List<IAction>>());
        }

        public TransferAction(IAccount owner)
        {
//            Owner = owner;
//            Links = new Dictionary<Queue<AccountType>, Queue<List<IAction>>>();
            AccountTypesInit();

        }

        public void Execute(IAccount initiator, IAccount receiver, uint amount)
        {
            throw new System.NotImplementedException();
        }

        private void TransferFromPersonToPerson(IAccount sender, IAccount receiver, uint amount)
        {
            // transfer transaction
        }

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
    }
} // TODO: доделать