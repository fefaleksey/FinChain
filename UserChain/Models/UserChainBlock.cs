using System;
using System.Collections.Generic;

namespace UserChain.Models
{
    public class UserChainBlock
    {
        public DateTime CreationTime { get; }
        public List<UserChainTransaction> Transactions { get; }
        public int PreviousBlockHash { get; }
        public int Hash { get; private set; }

        public UserChainBlock(List<UserChainTransaction> transactions, int previousBlockHash)
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