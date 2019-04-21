using System.Net.Http;
using System.Text;
using FinChain.Models;
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
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
            var indented = Formatting.Indented;

            //            var kek = new RuleTransaction();
//            var jsonKek = JsonConvert.SerializeObject(kek, indented, settings);
            
            var json = JsonConvert.SerializeObject(ruleTransaction);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.PostAsync($"{nodeUrl}/api/transactions/addToPool", content);

//            var lol = JsonConvert.DeserializeObject<RuleTransaction>(jsonKek, settings);

            
            //            var lol = JsonConvert.DeserializeObject<IRuleTransaction>(test);

//            throw new NotImplementedException();
        }
    }
}