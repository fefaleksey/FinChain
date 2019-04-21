using System.Collections.Generic;
using FinChain.Models.Actions;
using RuleChain.Models;

namespace RuleChain.State
{
    public interface IState
    {
        void UpdateState(IBlock block);
        IActionRequirements GetRequirement(RequirementId requirementId);
        List<IActionRequirements> GetAllRequirements();
    }
}