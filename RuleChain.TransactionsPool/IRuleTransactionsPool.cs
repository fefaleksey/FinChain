using System.Collections.Generic;
using RuleChain.Models;

namespace RuleChain.TransactionsPool
{
    internal interface IRuleTransactionsPool
    {
        void Push(RuleTransaction ruleTransaction);
        
        /// <summary>
        /// Get 1 ruleTransaction from pool.
        /// </summary>
        /// <returns>RuleTransaction.</returns>
        RuleTransaction Get();
        
        /// <summary>
        /// Get list of transactions from pool.
        /// </summary>
        /// <param name="quantity">Number of transactions.</param>
        /// <returns>List of "quantity" (or less if there are not enough) ruleTransaction.</returns>
        List<RuleTransaction> Get(int quantity);
    }
}