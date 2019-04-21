using System;
using System.Collections.Generic;
using FinChain.Models.Actions;
using RuleChain.Models;
using RuleChain.State;

namespace RuleChain
{
    internal class Chain : IChain
    {
        private readonly IState _state = new State.State();
        public IBlock Genesis { get; }

        public Chain()
        {
            Genesis = new Block(null, new HashCode());
        }

        public void CommitBlock(IBlock block)
        {
            throw new NotImplementedException();
        }

        public IActionRequirements GetRequirement(RequirementId id) => _state.GetRequirement(id);

        public List<IActionRequirements> GetAllRequirements() => _state.GetAllRequirements();
    }
}