using System;
using System.Collections.Generic;

namespace RuleChain.Models
{
    public class Block : IBlock
    {
        public DateTime CreationTime { get; }
        public List<RuleTransaction> Transactions { get; }
        public HashCode PreviousBlockHash { get; }
        public HashCode Hash { get; } = new HashCode();

        public Block(List<RuleTransaction> transactions, HashCode previousBlockHash)
        {
            Transactions = transactions;
            CreationTime = DateTime.UtcNow;
            PreviousBlockHash = previousBlockHash;
            // TODO: calculate hash
            CalculateHash();
        }

        private void CalculateHash()
        {
            Hash.Add(CreationTime);
            Hash.Add(Transactions);
            Hash.Add(PreviousBlockHash);
        }
    }
}