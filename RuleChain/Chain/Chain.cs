using System;

namespace RuleChain.Chain
{
    internal class Chain : IChain
    {
        public IState State { get; }
        public IBlock Genesis { get; }
        
        public Chain()
        {
            Genesis = new Block(null, null);
            State = new State();
        }
        
        public void AddBlock(IBlock block)
        {
            throw new NotImplementedException();
        }
    }
}