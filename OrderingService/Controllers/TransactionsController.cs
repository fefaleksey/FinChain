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
        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"value1", "value2"};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
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