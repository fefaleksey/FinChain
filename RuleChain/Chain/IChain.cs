using System;

namespace RuleChain.Chain
{
    internal interface IChain
    {
        IBlock Genesis { get; }
        DateTime CreationTime { get; }
        
    }
}