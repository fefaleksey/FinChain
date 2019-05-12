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

        public void CommitBlock(UserChainBlock userChainBlock) => _chain.CommitBlock(userChainBlock);

        public int GetLastBlockHash()
        {
            var block = _chain.GetLastBlock();
            return block.Hash;
        }
    }
}