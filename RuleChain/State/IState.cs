using FinChain.Models.Actions;
using RuleChain.Models;

namespace RuleChain.State
{
    public interface IState
    {
        void UpdateState(RuleBlock block);
        IActionRequirements GetRequirements(ActionType type);
    }
}