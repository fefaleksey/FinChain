using System.Collections.Generic;
using RuleChain.Rules;

namespace RuleChain.Chain
{
    public interface IState
    {
        List<IRule> Rules { get; }
        
        void UpdateState(IBlock block);
    }
}