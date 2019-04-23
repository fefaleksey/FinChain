using FinChain.Models;
using Microsoft.AspNetCore.Mvc;
using RuleChain.Models;

namespace NotaryNode.Controllers
{
    [Route("api/[controller]")]    
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        [HttpPost]//, Route("addEvent")] //api/transactions/addEvent
        public void AddTransactionEvent([FromBody] TransactionEvent transactionEvent)
        {
            int a;
        }

        [HttpPost, Route("addToPool")]
        public void AddTransactionToPool([FromBody] RuleTransaction ruleTransaction)
        {
            int a;
            
//            var obj =  JsonConvert.DeserializeObject<RuleTransaction>(JsonString, settings);
        }
    }
}