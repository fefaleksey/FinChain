using System;
using System.Collections.Generic;
using Actions;

namespace RuleChain.Chain
{
    public interface IState
    {
        void UpdateState(IBlock block);
        IRequirements GetRequirement(Guid id);
        List<IRequirements> GetAllRequirements();
    }
}