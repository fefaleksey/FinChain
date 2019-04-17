using System.Collections.Generic;

namespace RuleChain.Transactions
{
    internal interface IRuleTransactionsPool
    {
        void Push(IRuleTransaction ruleTransaction);
        
        /// <summary>
        /// Get 1 ruleTransaction from pool.
        /// </summary>
        /// <returns>RuleTransaction.</returns>
        IRuleTransaction Get();
        
        /// <summary>
        /// Get list of transactions from pool.
        /// </summary>
        /// <param name="quantity">Number of transactions.</param>
        /// <returns>List of "quantity" (or less if there are not enough) ruleTransaction.</returns>
        List<IRuleTransaction> Get(int quantity);
    }
}