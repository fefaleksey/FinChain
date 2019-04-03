using FinChain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NotaryNode.Client;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace Government.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovernmentApiGatewayController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly INotaryNodeClient _notaryNodeClient;

        public GovernmentApiGatewayController(IConfiguration configuration, INotaryNodeClient notaryNodeClient)
        {
            _configuration = configuration;
            _notaryNodeClient = notaryNodeClient;
        }
        
//        [HttpPost, Route("addEvent")] 
        [HttpPost]
        public void BroadcastRuleToNotaryNodes([FromBody] TransactionEvent transactionEvent)
        {
            var urls = _configuration.GetSection("NotaryNodes").Get<string[]>();
            
//            var urls = new []{"http://localhost:5000"};
            
            foreach (var url in urls)
            {
                _notaryNodeClient.AddTransactionEvent(url, transactionEvent);
            }
        }
        
        [HttpPost, Route("addEvent")] 
        public void AddTransactionEvent([FromBody] TransactionEvent transactionEvent)
        {
            var urls = _configuration.GetSection("NotaryNodes").Get<string[]>();
            
//            var urls = new []{"http://localhost:5000"};
            
            foreach (var url in urls)
            {
                _notaryNodeClient.AddTransactionEvent(url, transactionEvent);
            }
        }
    }
}