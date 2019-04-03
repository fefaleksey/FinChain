using System;
using System.Collections.Generic;
using RuleChain.Transactions;

namespace RuleChain
{
    internal interface IBlock
    {
        DateTime CreationTime { get; }
        List<ITransaction> Transactions { get; }
        HashCode Hash { get; }
        HashCode PreviousBlockHash { get; }
        IAddress FormedBy { get; }
    }
}