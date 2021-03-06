﻿using Microsoft.AspNetCore.Mvc;
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
        
        [HttpPost, Route("addTransaction")]
        public void AddTransaction([FromBody] UserChainTransaction transaction)
        {
            UserChainVerifier.Verify(transaction);
            _transactionsPool.Push(transaction);
        }
    }
}