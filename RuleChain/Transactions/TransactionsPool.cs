using System.Collections.Generic;

namespace RuleChain.Transactions
{
    internal class TransactionsPool : ITransactionsPool
    {
        private readonly Queue<ITransaction> _transactions = new Queue<ITransaction>();       
        
        public void Push(ITransaction transaction)
        {
            _transactions.Enqueue(transaction);
        }

        public ITransaction Get()
        {
            return _transactions.Dequeue();
        }

        public List<ITransaction> Get(int quantity)
        {
            throw new System.NotImplementedException();
        }
    }
}