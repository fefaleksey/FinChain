using System.Collections.Generic;

namespace RuleChain.Transactions
{
    internal interface ITransactionsPool
    {
        void Push(ITransaction transaction);
        
        /// <summary>
        /// Get 1 transaction from pool.
        /// </summary>
        /// <returns>Transaction.</returns>
        ITransaction Get();
        
        /// <summary>
        /// Get list of transactions from pool.
        /// </summary>
        /// <param name="quantity">Number of transactions.</param>
        /// <returns>List of "quantity" (or less if there are not enough) transaction.</returns>
        List<ITransaction> Get(int quantity);
    }
}