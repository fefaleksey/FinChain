using System.Net.Http;
using FinChain.Models;

namespace NotaryNode.Client
{
    public interface INotaryNodeClient
    {
        void AddTransactionEvent(string nodeUrl, TransactionEvent transactionEvent);
        void AddTransactionToPool();
    }
}