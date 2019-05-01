using UserChain.Transactions;

namespace UserChain.Controller
{
    public interface IUserChainController
    {
        void CommitBlock(Block block);

        int GetLastBlockHash();
    }
}