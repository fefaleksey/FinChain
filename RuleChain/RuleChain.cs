using System;
using System.Collections.Generic;
using FinChain.Models.Actions;
using RuleChain.Models;
using RuleChain.State;

namespace RuleChain
{
    public class RuleChain : IRuleChain
    {
        private readonly IState _state = new State.State();
        public RuleBlock Genesis { get; }

        private List<RuleBlock> _chain = new List<RuleBlock>();
        
        public RuleChain()
        {
            Genesis = new RuleBlock(null, 0);
            _chain.Add(Genesis);
        }

        public void CommitBlock(RuleBlock block)
        {
            _chain.Add(block);
            _state.UpdateState(block);
        }

        public IActionRequirements GetRequirements(ActionType type) => _state.GetRequirements(type);
        
        public RuleBlock GetLastBlock()
        {
            return _chain[_chain.Count - 1];
        }
    }
}