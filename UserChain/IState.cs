using UserChain.Transactions;

namespace UserChain
{
    interface IState
    {
        void UpdateState(Block block);
    }
}