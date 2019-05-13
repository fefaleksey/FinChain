using FinChain.Models.Accounts;
using UserChain.Models;

namespace UserChain.Controller
{
    public interface IUserChainController
    {
        void CommitBlock(UserChainBlock userChainBlock);
        bool AddAccount(Account account);
        int GetLastBlockHash();
    }
}