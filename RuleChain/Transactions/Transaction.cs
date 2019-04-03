using System;
using System.Collections.Generic;
using RuleChain.Rules;
using RuleChain.Transactions.Enums;
using UserChain.Accounts;

namespace RuleChain.Transactions
{
    public class Transaction : ITransaction
    {
        public DateTime Time { get; }
        public TransactionStatus Status { get; }
        public List<AccountType> AffectsOn { get; }
        public HashCode? OldRuleHash { get; }
        public IRule Rule { get; }

        public Transaction(IRule rule)
        {
            Rule = rule;
            Time = DateTime.UtcNow;
            Status = TransactionStatus.Created;
            AffectsOn = Rule?.AffectsOn;
            OldRuleHash = null;
        }
        
        public Transaction(IRule rule, HashCode oldRuleHash)
        {
            Rule = rule;
            OldRuleHash = oldRuleHash;
            Time = DateTime.UtcNow;
            Status = TransactionStatus.Created;
            AffectsOn = Rule.AffectsOn;
        }
        
        public TransactionType Type()
        {
            throw new NotImplementedException();
        }
    }
}