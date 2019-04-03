using System;

namespace RuleChain.Chain
{
    internal interface IChain
    {
        IState State { get; }
        IBlock Genesis { get; }

        void AddBlock(IBlock block);
    }
}