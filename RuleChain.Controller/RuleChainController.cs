using FinChain.Models.Actions;
using RuleChain;

namespace RuleChain.Controller
{
    public class RuleChainController : IRuleChainController
    {
        private readonly IRuleChain _chain;

        private RuleChainController(IRuleChain chain)
        {
            _chain = chain;
        }

        public IActionRequirements GetRequirement(RequirementId id) => _chain.GetRequirement(id);
    }
}