using System.Collections.Generic;
using FinChain.Models.Accounts;

namespace FinChain.Models.Actions
{
    public interface IAction
    {
        ActionId Id { get; }

        bool IsActive { get; }
        
        List<AccountType> AccessToDeploy { get; }

        ActionExecutionResult Execute(Account sender, params object[] list);
    }
}