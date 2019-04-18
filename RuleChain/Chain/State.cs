using System;
using System.Collections;
using System.Collections.Generic;
using Actions;
using RuleChain.Rules;
using RuleChain.Transactions;

namespace RuleChain.Chain
{
    public class State : IState
    {
        private Dictionary<Guid, IRequirements> _requirements;
        public List<IRequirements> Rules { get; } = new List<IRequirements>();
        
        public void UpdateState(IBlock block)
        {
            var visitor = new RuleTransactionVisitor();
            foreach (var transaction in block.Transactions)
            {
                transaction.Apply(visitor);
            }
            throw new System.NotImplementedException();
        }

        public IRequirements GetRequirement(Guid id)
        {
            return _requirements[id];
        }


        public List<IRequirements> GetAllRequirements()
        {
            throw new NotImplementedException();
        }
    }
}