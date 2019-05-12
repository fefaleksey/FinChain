using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TransactionPool;
using UserChain;
using UserChain.Models;

namespace OrderingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsPool<UserChainTransaction> _transactionsPool;
        public TransactionsController(ITransactionsPool<UserChainTransaction> transactionsPool)
        {
            _transactionsPool = transactionsPool;
        }
        
        // POST api/values
        [HttpPost, Route("add")]
        public void AddTransaction([FromBody] UserChainTransaction transaction)
        {
            UserChainVerifier.Verify(transaction);
            _transactionsPool.Push(transaction);
        }
    }
}