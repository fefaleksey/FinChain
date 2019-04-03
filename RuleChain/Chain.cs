﻿using System;

namespace RuleChain
{
    internal class Chain : IChain
    {
        public IBlock Genesis { get; }
        public DateTime CreationTime { get; }
        
        public Chain(IBlock genesis, DateTime creationTime, string metaData)
        {
            Genesis = genesis;
            CreationTime = creationTime;
        }
    }
}
