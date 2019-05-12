using System.Collections.Generic;

namespace TransactionPool
{
    public interface ITransactionsPool<T>
    {
        void Push(T transaction);
        
        /// <summary>
        /// Get 1 ruleTransaction from pool.
        /// </summary>
        /// <returns>Transaction.</returns>
        T Get();
        
        /// <summary>
        /// Get all transactions from pool.
        /// </summary>
        /// <returns>Transactions List.</returns>
        List<T> GetAll();
        
        /// <summary>
        /// Get list of transactions from pool.
        /// </summary>
        /// <param name="quantity">Number of transactions.</param>
        /// <returns>List of "quantity" (or less if there are not enough) transactions.</returns>
        List<T> Get(int quantity);
    }
}