using System;
using System.Collections.Generic;
using FinChain.Models.Accounts;

namespace RuleChain.Rules
{
    public class Rule : IRule
    {
        public IRuleId Id { get; } // TODO: initialize
        public HashCode Hash { get; }
        public List<AccountType> AffectsOn { get; }

        public Rule()
        {
            Id = new RuleId("Test Rule");
        }

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