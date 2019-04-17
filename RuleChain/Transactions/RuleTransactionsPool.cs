using System.Collections.Generic;

namespace RuleChain.Transactions
{
    internal class RuleTransactionsPool : IRuleTransactionsPool
    {
        private readonly Queue<IRuleTransaction> _transactions = new Queue<IRuleTransaction>();       
        
        public void Push(IRuleTransaction ruleTransaction)
        {
            _transactions.Enqueue(ruleTransaction);
        }

        public IRuleTransaction Get()
        {
            return _transactions.Dequeue();
        }

        public List<IRuleTransaction> Get(int quantity)
        {
            throw new System.NotImplementedException();
        }
    }
}