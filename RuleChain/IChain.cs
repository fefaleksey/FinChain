using System;

namespace RuleChain
{
    internal interface IChain
    {
        IBlock Genesis { get; }
        DateTime CreationTime { get; }
        
    }
}