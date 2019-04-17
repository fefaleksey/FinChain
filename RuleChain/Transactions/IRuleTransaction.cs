using System;
using System.Collections.Generic;
using RuleChain.Rules;
using RuleChain.Transactions.Enums;
using UserChain.Accounts;

namespace RuleChain.Transactions
{
    public interface IRuleTransaction
    {
        
        DateTime Time { get; }

        TransactionStatus Status { get; }
        List<AccountType> AffectsOn { get; }    //TODO: qn: enum or something else?
        
        /// <summary>
        /// Hash of old rule.
        /// If OldRuleHash == null then Type = deploy.
        /// If OldRuleHash != null then Type = change or remove.
        /// </summary>
        HashCode? OldRuleHash { get; }
        
        /// <summary>
        /// If Rule == null then Type == remove.
        /// If Rule != null and OldRuleHash != null then Type == change.
        /// </summary>
        IRule Rule { get; }
        
        /// <summary>
        /// Type of transaction.
        /// </summary>
        /// <returns>Enum value.</returns>
        TransactionType Type();
    }
}