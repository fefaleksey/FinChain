using System;
using System.Collections.Generic;

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