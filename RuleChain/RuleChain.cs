using System;
using System.Collections.Generic;
using RuleChain.Rules;

namespace RuleChain
{
    public class RuleChain : IRuleChain
    {
        
        private Dictionary<byte, IRule> _state;
        public bool AddTransactionToPool()
        {
            throw new NotImplementedException();
        }
    }
}