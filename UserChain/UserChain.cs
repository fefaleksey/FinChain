using System.Collections.Generic;
using FinChain.Models.Accounts;
using UserChain.Models;

namespace UserChain
{
    public class UserChain : IUserChain
    {
        private readonly IState _state = new State();
        public UserChainBlock Genesis { get; }

        private readonly List<UserChainBlock> _chain = new List<UserChainBlock>();
        
        public UserChain()
        {
            Genesis = new UserChainBlock(null, 0);
            _chain.Add(Genesis);
        }

        public void CommitBlock(UserChainBlock userChainBlock)
        {
            _chain.Add(userChainBlock);
            _state.UpdateState(userChainBlock);
        }

        public bool AddAccount(Account account)
        {
            return _state.AddAccount(account);
        }

        public UserChainBlock GetLastBlock()
        {
            return _chain[_chain.Count - 1];
        }
    }
}