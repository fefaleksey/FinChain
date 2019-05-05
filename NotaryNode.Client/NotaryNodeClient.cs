using System;
using System.Net.Http;
using System.Text;
using FinChain.Models;
using FinChain.Models.Actions;
using Newtonsoft.Json;
using RuleChain.Models;

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
//            Newtonsoft.Json.JsonConvert.SerializeObject
            _httpClient.PostAsync($"{nodeUrl}/api/transactions/addEvent", null);
        }

        public void AddTransactionToPool(string nodeUrl, RuleTransaction ruleTransaction)
        {
            var json = JsonConvert.SerializeObject(ruleTransaction);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.PostAsync($"{nodeUrl}/api/transactions/addToPool", content);
        }

        public async void SendBlock(string nodeUrl, RuleBlock block)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
//            const Formatting indented = Formatting.Indented;
            var json = JsonConvert.SerializeObject(block, settings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // plug for debugging
            try
            {
                await _httpClient.PostAsync($"{nodeUrl}/api/transactions/addBlock", content);
            }
            catch (Exception e)
            {
                Console.WriteLine("===========================================================================");
                Console.WriteLine(e);
                Console.WriteLine("===========================================================================");
            }
        }

        public IActionRequirements GetRequirements(ActionType type)
        {
            throw new NotImplementedException();
        }
    }
}