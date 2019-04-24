using System.Collections.Generic;
using FinChain.Models.Actions;
using RuleChain.Models;

namespace RuleChain.Controller
{
    public interface IRuleChainController
    {
        void CommitBlock(IBlock block);
        
        IActionRequirements GetRequirements(ActionType type);
    }
}