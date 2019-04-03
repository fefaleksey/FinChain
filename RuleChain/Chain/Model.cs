using System;
using System.Collections.Generic;
using RuleChain.Rules;

namespace RuleChain.Chain
{
    internal class Model : IModel
    {
        private Dictionary<byte, List<IRule>> _state = new Dictionary<byte, List<IRule>>();

        public List<IRule> Rule(byte type)
        {
            if (_state.ContainsKey(type))
            {
                return _state[type];
            }
            throw new ArgumentException("Invalid argument. There is not rule of type" + type);
        }
    }
}
