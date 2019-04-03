using System;
using System.Collections.Generic;
using RuleChain.Transactions;

namespace RuleChain.Chain
{
    internal interface IBlock
    {
        DateTime CreationTime { get; }
        List<ITransaction> Transactions { get; }
        HashCode Hash { get; }
        HashCode PreviousBlockHash { get; }
//        IRuleAddress FormedBy { get; }
    }
}