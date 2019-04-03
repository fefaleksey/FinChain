using RuleChain.Transactions;

namespace RuleChain
{
    public class Rule : IRule
    {
        public bool Check(ITransaction transaction)
        {
            throw new System.NotImplementedException();
        }
    }
}