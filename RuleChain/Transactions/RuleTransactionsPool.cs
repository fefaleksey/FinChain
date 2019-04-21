using System;
using System.Collections.Generic;
using RuleChain.Models;

namespace RuleChain.Transactions
{
    internal class RuleTransactionsPool : IRuleTransactionsPool
    {
        private readonly Queue<RuleTransaction> _transactions = new Queue<RuleTransaction>();       
        
        public void Push(RuleTransaction ruleTransaction)
        {
            _transactions.Enqueue(ruleTransaction);
        }

        public RuleTransaction Get()
        {
            return _transactions.Dequeue();
        }

        public List<RuleTransaction> Get(int quantity)
        {
            var limit = Math.Min(quantity, _transactions.Count);
            var list = new  List<RuleTransaction>();

            for (int i = 0; i < limit; i++)
            {
                list.Add(_transactions.Dequeue());
            }

            return list;
        }
    }
}