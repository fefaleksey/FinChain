using FinChain.Models.Actions;
using RuleChain.Models;

namespace RuleChain.Controller
{
    public interface IRuleChainController
    {
        void CommitBlock(RuleBlock block);
        
        IActionRequirements GetRequirements(ActionType type);

        int GetLastBlockHash();
    }
}