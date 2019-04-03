using System;
using System.Net.Http;
using FinChain.Models;

namespace NotaryNode.Client
{
    public class NotaryNodeClient : INotaryNodeClient
    {
        private readonly HttpClient _httpClient;

        public NotaryNodeClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public void AddTransactionEvent(string nodeUrl, TransactionEvent transactionEvent)
        {
            _httpClient.PostAsync($"{nodeUrl}/api/transactions/addEvent", null);
        }

        public void AddTransactionToPool()
        {
            throw new NotImplementedException();
        }
    }
}