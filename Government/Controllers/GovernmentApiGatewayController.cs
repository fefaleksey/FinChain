using System.Net.Mail;
using Actions;
using FinChain.Models;
using FinChain.Models.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NotaryNode.Client;
using RuleChain.Models;
using RuleChain.TransactionsPool;
using System.Web;

namespace Government.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovernmentApiGatewayController : ControllerBase
    {
        private readonly IRuleTransactionsPool _transactionsPool;
        private readonly IConfiguration _configuration;
        private readonly INotaryNodeClient _notaryNodeClient;

        public GovernmentApiGatewayController(IConfiguration configuration, INotaryNodeClient notaryNodeClient,
            IRuleTransactionsPool transactionsPool)
        {
            _configuration = configuration;
            _notaryNodeClient = notaryNodeClient;
            _transactionsPool = transactionsPool;
        }
        
        [HttpPost, Route("addAction")]
        public void CreateAddAction([FromBody] ActionType type)
        {
            var requirements = ActionRequirementBuilder.Create(type);
            var ruleTransaction = RuleTransaction.CreateAddActionTransaction(type, requirements);
            _transactionsPool.Push(ruleTransaction);
        }
    }
}