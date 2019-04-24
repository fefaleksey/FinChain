using System;
using System.Collections.Generic;

namespace RuleChain.Models
{
    public class Block : IBlock
    {
        public DateTime CreationTime { get; }
        public List<RuleTransaction> Transactions { get; }
        public int PreviousBlockHash { get; }
        public int Hash { get; private set; }

        public Block(List<RuleTransaction> transactions, int previousBlockHash)
        {
            Transactions = transactions;
            CreationTime = DateTime.UtcNow;
            PreviousBlockHash = previousBlockHash;
            CalculateHash();
        }

        private void CalculateHash()
        {
            var hashCode = new HashCode();
            hashCode.Add(CreationTime);
            hashCode.Add(Transactions);
            hashCode.Add(PreviousBlockHash);
            Hash = hashCode.ToHashCode();
        }
    }
}