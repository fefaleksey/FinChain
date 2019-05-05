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

        [HttpPost, Route("addAction")]
        public void AddAction([FromBody] ActionType type)
        {
            var requirements = ActionRequirementBuilder.Create(type);
            var ruleTransaction = RuleTransaction.CreateAddActionTransaction(type, requirements);
            _transactionsPool.Push(ruleTransaction);
        }

        [HttpPost, Route("addRequirement")]
        public void AddRequirement([FromBody] ActionType typeKey, ActionType typeValue, JObject jsonRequirement,
            int step)
        {
            var requirement = jsonRequirement.ToObject<IActionRequirements>(new JsonSerializer()
            {
                TypeNameHandling = TypeNameHandling.All
            });
            var ruleTransaction =
                RuleTransaction.CreateAddRequirementsTransaction(typeKey, typeValue, requirement, step);
            _transactionsPool.Push(ruleTransaction);
        }
    }
}