using System;
using UserChain;

namespace RuleChain.Chain
{
    internal interface IChain
    {
        IState State { get; }
        IBlock Genesis { get; }

        void CommitBlock(IBlock block);
    }
}