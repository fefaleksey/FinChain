using RuleChain.Models;
using RuleChain.Models.Enums;

namespace RuleChain
{
    public static class RuleTransactionsVerifier
    {
        // TODO: implement
        public static void Verify(RuleTransaction transaction)
        {
            transaction.Status = TransactionStatus.Valid;
        }
    }
}