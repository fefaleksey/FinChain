using System.Net.Http;
using FinChain.Models;
using RuleChain.Transactions;

namespace NotaryNode.Client
{
    public interface INotaryNodeClient
    {
        void AddTransactionEvent(string nodeUrl, TransactionEvent transactionEvent);
        void AddTransactionToPool(string nodeUrl, RuleTransaction ruleTransaction);
    }
}