using FinChain.Models;
using UserChain.Models;

namespace UserChain
{
    public static class UserChainVerifier
    {
        public static void Verify(UserChainTransaction transaction)
        {
            transaction.Status = TransactionStatus.Valid;
        }
        
        public static void Verify(UserChainBlock block)
        {
            foreach (var transaction in block.Transactions)
            {
                Verify(transaction);
            }
        }
        
        public static bool CheckCorrectness(UserChainBlock block)
        {
            return true;
        }
    }
}