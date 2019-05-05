using Actions;
using FinChain.Models.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NotaryNode.Client;
using RuleChain.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TransactionPool;

namespace Government.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovernmentApiGatewayController : ControllerBase
    {
        private readonly ITransactionsPool<RuleTransaction> _transactionsPool;
        private readonly IConfiguration _configuration;
        private readonly INotaryNodeClient _notaryNodeClient;

        public GovernmentApiGatewayController(IConfiguration configuration, INotaryNodeClient notaryNodeClient,
            ITransactionsPool<RuleTransaction> transactionsPool)
        {
            _configuration = configuration;
            _notaryNodeClient = notaryNodeClient;
            _transactionsPool = transactionsPool;
        }

        [HttpPost, Route("addTransaction")]
        public void AddTransaction([FromBody] RuleTransaction transaction)
        {
            _transactionsPool.Push(transaction);
        }
    }
}