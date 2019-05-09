using System.Collections.Generic;
using System.Net.Http;
using Actions;
using FinChain.Models.Actions;
using NotaryNode.Client;
using RuleChain.Controller;
using RuleChain.Models;
using RuleChain.Models.Enums;
using Xunit;

namespace RuleChain.Tests
{
    public class IntegrationTests
    {
        private readonly RuleChain _chain;
        private readonly RuleChainController _controller;

        public IntegrationTests()
        {
            _chain = new RuleChain();
            _controller = new RuleChainController(_chain);
        }
        
        [Fact]
        public void CommitBlockTest()
        {
            var transaction = RuleTransaction.CreateAddActionTransaction(ActionType.TransferFromPersonToPerson);
            transaction.Status = TransactionStatus.Valid;
            var block = new RuleBlock(new List<RuleTransaction> {transaction}, _controller.GetLastBlockHash());
            var requirements = _chain.GetRequirements(ActionType.TransferFromPersonToPerson);
            Assert.Null(requirements);
            
            _chain.CommitBlock(block);
            requirements = _chain.GetRequirements(ActionType.TransferFromPersonToPerson);
            Assert.Empty(requirements.GetAllRequirements());
            
            var builder = new ActionBuilder(_controller, new NotaryNodeClient(new HttpClient()));
            transaction = RuleTransaction.CreateAddRequirementsTransaction(ActionType.TransferFromPersonToPerson,
                builder.Create(ActionType.PayTax, "http://localhost:5000"),
                0);
            transaction.Status = TransactionStatus.Valid;
            block = new RuleBlock(new List<RuleTransaction> {transaction}, _controller.GetLastBlockHash());
            _chain.CommitBlock(block);
            Assert.NotEmpty(requirements.GetAllRequirements());
        }
    }
}