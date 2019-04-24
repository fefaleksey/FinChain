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
        public IBlock Genesis { get; }

        public RuleChain()
        {
            Genesis = new Block(null, new HashCode());
        }

        public void CommitBlock(IBlock block) => _state.UpdateState(block);

        public IActionRequirements GetRequirements(ActionType type) => _state.GetRequirements(type);
    }
}