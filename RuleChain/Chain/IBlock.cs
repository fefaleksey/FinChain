﻿using System;
using System.Collections.Generic;
using RuleChain.Transactions;

namespace RuleChain.Chain
{
    public interface IBlock
    {
        DateTime CreationTime { get; }
        List<RuleTransaction> Transactions { get; }
        HashCode? PreviousBlockHash { get; }
        HashCode Hash { get; }
    }
}