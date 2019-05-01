﻿using UserChain.Transactions;

namespace UserChain
{
    public interface IUserChain
    {
        Block Genesis { get; }
        void CommitBlock(Block block);
        Block GetLastBlock();
    }
}