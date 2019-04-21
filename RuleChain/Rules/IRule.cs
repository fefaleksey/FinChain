using System;
using System.Collections.Generic;
using FinChain.Models.Accounts;

namespace RuleChain.Rules
{
    public interface IRule
    {
        IRuleId Id { get; }
        HashCode Hash { get; }
        List<AccountType> AffectsOn { get; }
        bool Check();
        bool CheckChanges();
    }
}