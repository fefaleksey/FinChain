using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Aq.ExpressionJsonSerializer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RuleChain.Models;
using RuleChain;
using TransactionPool;
using System.IO;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CSharp;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Text;
using System.Linq;

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