using System.Collections.Generic;
using RuleChain.Rules;

namespace RuleChain.Chain
{
    public class State : IState
    {
        public List<IRule> Rules { get; } = new List<IRule>();
        
        public void UpdateState(IBlock block)
        {
            throw new System.NotImplementedException();
        }
    }
}