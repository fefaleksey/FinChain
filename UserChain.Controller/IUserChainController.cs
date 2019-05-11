using UserChain.Models;

namespace UserChain.Controller
{
    public interface IUserChainController
    {
        void CommitBlock(UserChainBlock userChainBlock);

        int GetLastBlockHash();
    }
}