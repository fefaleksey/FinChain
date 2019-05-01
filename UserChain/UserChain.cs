using System.Collections.Generic;

namespace UserChain
{
    public class UserChain : IUserChain
    {
        private readonly IState _state = new State();
        public Block Genesis { get; }

        private readonly List<Block> _chain = new List<Block>();
        
        public UserChain()
        {
            Genesis = new Block(null, 0);
            _chain.Add(Genesis);
        }

        public void CommitBlock(Block block)
        {
            _chain.Add(block);
            _state.UpdateState(block);
        }

        
        public Block GetLastBlock()
        {
            return _chain[_chain.Count - 1];
        }
    }
}