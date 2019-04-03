using System;
using System.Collections.Generic;
using RuleChain.Transactions;

namespace RuleChain.Chain
{
    internal class Block : IBlock
    {
        public DateTime CreationTime { get; }
        public List<ITransaction> Transactions { get; }
        public HashCode Hash { get; }
        public HashCode PreviousBlockHash { get; }
        
        public Block(List<ITransaction> transactions, DateTime creationTime, HashCode previousBlockHash)
        {
            Transactions = transactions;
            CreationTime = creationTime;
            PreviousBlockHash = previousBlockHash;
            
            // TODO: calculate hash
        }
    }
}