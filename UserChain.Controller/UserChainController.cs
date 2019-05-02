using UserChain.Models;

namespace UserChain.Controller
{
    public class UserChainController : IUserChainController
    {
        private readonly UserChain _chain;
        public UserChainController(UserChain chain)
        {
            _chain = chain;
        }

        public void CommitBlock(Block block) => _chain.CommitBlock(block);

        public int GetLastBlockHash()
        {
            var block = _chain.GetLastBlock();
            return block.Hash;
        }
    }
}