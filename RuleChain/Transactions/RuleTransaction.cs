using System;
using System.Collections.Generic;
using RuleChain.Rules;
using RuleChain.Transactions.Enums;
using UserChain.Accounts;

namespace RuleChain.Transactions
{
    public class RuleTransaction : IRuleTransaction
    {
        public DateTime Time { get; }
        public TransactionStatus Status { get; }
        public List<AccountType> AffectsOn { get; }
        public HashCode? OldRuleHash { get; }
        public IRule Rule { get; }

        // DO NOT USE!!! IT IS FOR SWAGGER!!!
        public RuleTransaction()
        {
            
        }
        
        public RuleTransaction(IRule rule)
        {
            Rule = rule;
            Time = DateTime.UtcNow;
            Status = TransactionStatus.Created;
            AffectsOn = Rule?.AffectsOn;
            OldRuleHash = null;
        }
        
        public RuleTransaction(IRule rule, HashCode oldRuleHash)
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