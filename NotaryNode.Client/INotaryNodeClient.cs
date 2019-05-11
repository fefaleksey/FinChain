using System.Threading.Tasks;
using FinChain.Models;
using FinChain.Models.Actions;
using RuleChain.Models;

namespace NotaryNode.Client
{
    public interface INotaryNodeClient
    {
        void AddTransactionEvent(string nodeUrl, TransactionEvent transactionEvent);
        void AddTransactionToPool(string nodeUrl, RuleTransaction ruleTransaction);
        void SendBlock(string nodeUrl, RuleBlock block);
        Task<IActionRequirements> GetRequirements(string nodeUrl, ActionType action);
    }
}