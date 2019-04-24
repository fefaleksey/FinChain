using System;
using FinChain.Models.Accounts;
using FinChain.Models.Actions;

namespace Actions
{
    public class PayTaxAction : IAction
    {
        public ActionId Id { get; }
        public RequirementId RequirementsId { get; }
        public bool IsActive { get; }
        
        private Account _taxService = new Account(AccountType.Government);
        
        public ActionExecutionResult Execute(Account sender, params object[] list)
        {
            throw new NotImplementedException();
        }
    }
}