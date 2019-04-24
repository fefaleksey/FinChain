using System.Collections.Generic;
using FinChain.Models.Actions;
using RuleChain;
using RuleChain.Models;

namespace RuleChain.Controller
{
    public class RuleChainController : IRuleChainController
    {
        private readonly IRuleChain _chain;

        public RuleChainController(IRuleChain chain)
        {
            _chain = chain;
        }

        public void CommitBlock(IBlock block) => _chain.CommitBlock(block);

        public IActionRequirements GetRequirements(ActionType type) => _chain.GetRequirements(type);
    }
}