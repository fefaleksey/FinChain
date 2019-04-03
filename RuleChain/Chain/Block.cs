using System;
using System.Collections.Generic;
using RuleChain.Transactions;

namespace RuleChain.Chain
{
    internal class Block : IBlock
    {
        public DateTime CreationTime { get; }
        public List<ITransaction> Transactions { get; }
        public HashCode? PreviousBlockHash { get; }
        public HashCode Hash { get; }

        public Block(List<ITransaction> transactions, HashCode? previousBlockHash)
        {
            Transactions = transactions;
            CreationTime = DateTime.UtcNow;
            PreviousBlockHash = previousBlockHash;
            // TODO: calculate hash
        }
    }
}