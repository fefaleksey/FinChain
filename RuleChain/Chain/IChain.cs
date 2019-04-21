using System.Collections.Generic;
using Actions;
using FinChain.Models.Actions;
using RuleChain.Models;

namespace RuleChain.Chain
{
    internal interface IChain
    {
        IBlock Genesis { get; }
        void CommitBlock(IBlock block);
        IActionRequirements GetRequirement(ActionId id);
        List<IActionRequirements> GetAllRequirements();
    }
}