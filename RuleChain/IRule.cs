using System.Collections.Generic;
using RuleChain.Transactions;

namespace RuleChain
{
    internal interface IRule
    {
        List<byte> DependOn { get; }
        bool Check(ITransaction transaction);
    }
}