using System;
using System.Collections.Generic;

namespace TransactionPool
{
    public class TransactionsPool<T> : ITransactionsPool<T>
    {
        private readonly Queue<T> _transactions = new Queue<T>();       
            
        public void Push(T transaction)
        {
            _transactions.Enqueue(transaction);
        }
    
        public T Get()
        {
            return _transactions.Dequeue();
        }
    
        public List<T> GetAll()
        {
            return Get(_transactions.Count);
        }
    
        public List<T> Get(int quantity)
        {
            var limit = Math.Min(quantity, _transactions.Count);
            var list = new  List<T>();
    
            for (int i = 0; i < limit; i++)
            {
                list.Add(_transactions.Dequeue());
            }
    
            return list;
        }
    }
}