using UserChain.Models;

namespace UserChain.Controller
{
    public interface IUserChainController
    {
        void CommitBlock(Block block);

        int GetLastBlockHash();
    }
}