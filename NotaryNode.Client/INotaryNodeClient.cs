using System.Threading.Tasks;
using FinChain.Models.Actions;
using RuleChain.Models;
using UserChain.Models;

namespace NotaryNode.Client
{
    public interface INotaryNodeClient
    {
        void SendBlock(string nodeUrl, RuleBlock block);
        void SendBlock(string nodeUrl, UserChainBlock block);
        Task<IActionRequirements> GetRequirements(string nodeUrl, ActionType action);
    }
}