using Microsoft.AspNetCore.Mvc;
using RuleChain.Models;
using RuleChain;
using TransactionPool;

namespace Government.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovernmentApiGatewayController : ControllerBase
    {
        private readonly ITransactionsPool<RuleTransaction> _transactionsPool;

        public GovernmentApiGatewayController(ITransactionsPool<RuleTransaction> transactionsPool)
        {
            _transactionsPool = transactionsPool;
        }

        [HttpPost, Route("addTransaction")]
        public void AddTransaction([FromBody] RuleTransaction transaction)
        {
            RuleTransactionsVerifier.Verify(transaction);
            _transactionsPool.Push(transaction);
        }
    }
}