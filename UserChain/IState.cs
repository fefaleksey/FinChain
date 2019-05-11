using UserChain.Models;

namespace UserChain
{
    interface IState
    {
        void UpdateState(UserChainBlock userChainBlock);
    }
}