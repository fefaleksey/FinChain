using FinChain.Models.Accounts;
using UserChain.Models;

namespace UserChain
{
    interface IState
    {
        void UpdateState(UserChainBlock userChainBlock);
        bool AddAccount(Account account);
    }
}