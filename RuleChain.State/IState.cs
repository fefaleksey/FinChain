using System.Collections.Generic;
using FinChain.Models.Actions;
using RuleChain.Models;

namespace RuleChain.State
{
    public interface IState
    {
        void UpdateState(IBlock block);
        IActionRequirements GetRequirement(ActionId requirementId);
        List<IActionRequirements> GetAllRequirements();
    }
}