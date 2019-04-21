using System.Collections.Generic;
using Actions;

namespace RuleChain.Chain
{
    public interface IState
    {
        void UpdateState(IBlock block);
        IActionRequirements GetRequirement(ActionId id);
        List<IActionRequirements> GetAllRequirements();
    }
}