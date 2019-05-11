using UserChain.Models;

namespace UserChain
{
    public interface IUserChain
    {
        UserChainBlock Genesis { get; }
        void CommitBlock(UserChainBlock userChainBlock);
        UserChainBlock GetLastBlock();
    }
}