using UserChain.Models;

namespace UserChain
{
    interface IState
    {
        void UpdateState(Block block);
    }
}