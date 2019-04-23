using System;
using System.Collections.Generic;

namespace RuleChain.Models
{
    public interface IBlock
    {
        DateTime CreationTime { get; }
        List<RuleTransaction> Transactions { get; }
        HashCode PreviousBlockHash { get; }
        HashCode Hash { get; }
    }
}