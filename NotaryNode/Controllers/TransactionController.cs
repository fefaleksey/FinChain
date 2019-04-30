using FinChain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RuleChain.Models;

namespace NotaryNode.Controllers
{
    [Route("api/[controller]")]    
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        [HttpPost, Route("addEvent")] //api/transactions/addEvent
        public void AddTransactionEvent([FromBody] TransactionEvent transactionEvent)
        {
            int a;
//            Response.SendFileAsync(200);
        }
        
        [HttpPost, Route("addBlock")]
        public void AddBlock([FromBody] JObject jsonBlock) //dynamic
        {
            var block = jsonBlock.ToObject<RuleBlock>(new JsonSerializer()
            {
                TypeNameHandling = TypeNameHandling.All
            });
            
        }
    }
}