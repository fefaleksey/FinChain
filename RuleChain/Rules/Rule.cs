using System;
using System.Collections.Generic;
using RuleChain.Transactions;
using UserChain.Accounts;

namespace RuleChain.Rules
{
    public class Rule : IRule
    {
        public IRuleId Id { get; } // TODO: initialize
        public HashCode Hash { get; }
        public List<AccountType> AffectsOn { get; }


        public bool Check()
        {
            throw new NotImplementedException();
        }

        public bool CheckChanges()
        {
            throw new NotImplementedException();
        }
    }
}