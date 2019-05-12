using FinChain.Models.Actions;
using RuleChain.Models;

namespace RuleChain
{
    public interface IRuleChain
    {
        RuleBlock Genesis { get; }
        void CommitBlock(RuleBlock block);
        IActionRequirements GetRequirements(ActionType type);
        RuleBlock GetLastBlock();
    }
}