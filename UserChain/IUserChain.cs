using FinChain.Models.Accounts;
using UserChain.Models;

namespace UserChain
{
    public interface IUserChain
    {
        UserChainBlock Genesis { get; }
        void CommitBlock(UserChainBlock userChainBlock);
        bool AddAccount(Account account);
        UserChainBlock GetLastBlock();
    }
}