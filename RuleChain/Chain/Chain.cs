using System;
using System.Collections.Generic;
using Actions;

namespace RuleChain.Chain
{
    internal class Chain : IChain
    {
        private readonly IState _state = new State();
        public IBlock Genesis { get; }

        public Chain()
        {
            Genesis = new Block(null, new HashCode());
        }

        public void CommitBlock(IBlock block)
        {
            throw new NotImplementedException();
        }

        public IRequirements GetRequirement(Guid id) => _state.GetRequirement(id);

        public List<IRequirements> GetAllRequirements() => _state.GetAllRequirements();
    }
}