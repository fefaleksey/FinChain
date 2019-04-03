using FinChain.Models;
using Microsoft.AspNetCore.Mvc;

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
        }
    }
}