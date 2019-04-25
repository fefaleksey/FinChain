using System;
using System.Collections.Generic;

namespace RuleChain.Models
{
    public interface IBlock
    {
        DateTime CreationTime { get; }
        List<RuleTransaction> Transactions { get; }
        int PreviousBlockHash { get; }
        int Hash { get; }
    }
}