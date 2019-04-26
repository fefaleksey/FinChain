using System.Collections.Generic;
using Actions;
using FinChain.Models.Actions;
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
            var transaction = RuleTransaction.CreateAddActionTransaction(ActionType.TransferFromPersonToPerson,
                new TransferFromPersonToPersonActionRequirements());
            transaction.Status = TransactionStatus.Valid;
            var block = new RuleBlock(new List<RuleTransaction> {transaction}, _controller.GetLastBlockHash());
            
            Assert.Null(_chain.GetRequirements(ActionType.TransferFromPersonToPerson));
            _chain.CommitBlock(block);
            Assert.NotNull(_chain.GetRequirements(ActionType.TransferFromPersonToPerson));
        }
    }
}