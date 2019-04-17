using System;
using System.Collections.Generic;
using RuleChain.Transactions;

namespace RuleChain.Chain
{
    public interface IBlock
    {
        DateTime CreationTime { get; }
        List<IRuleTransaction> Transactions { get; }
        HashCode? PreviousBlockHash { get; }
        HashCode Hash { get; }
    }
}