using System;
using System.Collections.Generic;
using RuleChain.Transactions;

namespace RuleChain
{
    internal class Block : IBlock
    {
        public Block(List<ITransaction> transactions, DateTime creationTime, IBlock previous,
            IBlock next, HashCode previousBlockHash)
        {
            CreationTime = creationTime;
            Previous = previous;
            Next = next;
            PreviousBlockHash = previousBlockHash;
        }

        public DateTime CreationTime { get; }
        public IBlock Previous { get; }
        public IBlock Next { get; }
        public HashCode Hash { get; }
        public HashCode PreviousBlockHash { get; }
    }
}