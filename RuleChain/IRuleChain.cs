using FinChain.Models.Actions;
using RuleChain.Models;

namespace RuleChain
{
    public interface IRuleChain
    {
        IBlock Genesis { get; }
        void CommitBlock(IBlock block);
        IActionRequirements GetRequirements(ActionType type);
        IBlock GetLastBlock();
    }
}