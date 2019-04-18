using System;
using System.Collections.Generic;
using Actions;

namespace RuleChain.Chain
{
    internal interface IChain
    {
        IBlock Genesis { get; }
        void CommitBlock(IBlock block);
        IRequirements GetRequirement(Guid id);
        List<IRequirements> GetAllRequirements();
    }
}