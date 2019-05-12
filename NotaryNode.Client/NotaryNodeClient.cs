using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FinChain.Models.Actions;
using Newtonsoft.Json;
using RuleChain.Models;
using UserChain.Models;

namespace NotaryNode.Client
{
    public class NotaryNodeClient : INotaryNodeClient
    {
        private readonly HttpClient _httpClient;

        public NotaryNodeClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async void SendBlock(string nodeUrl, RuleBlock block)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
            var json = JsonConvert.SerializeObject(block, settings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                await _httpClient.PostAsync($"{nodeUrl}/api/RuleChainApiGateway/addBlock", content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public async void SendBlock(string nodeUrl, UserChainBlock block)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
            var json = JsonConvert.SerializeObject(block, settings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                await _httpClient.PostAsync($"{nodeUrl}/api/UserChainApiGateway/addBlock", content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // TODO: implement
        public async Task<IActionRequirements> GetRequirements(string nodeUrl, ActionType action)
        {
            var lol = await _httpClient.GetAsync($"{nodeUrl}/api/RuleChainApiGateway/getRequirements/?action={action}");
            var kek = await lol.Content.ReadAsStringAsync();
            var requirements = JsonConvert.DeserializeObject<ActionRequirements>(kek);
            return requirements;
        }
    }
}