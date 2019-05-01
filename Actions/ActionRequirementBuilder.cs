using System;
using FinChain.Models.Actions;

namespace Actions
{
    public static class ActionRequirementBuilder
    {
        public static IActionRequirements Create(ActionType type)
        {
            switch (type)
            {
                case ActionType.TransferFromPersonToPerson:
                {
                    return CreateTransferFromPersonToPersonActionRequirements();
                }
                case ActionType.PayTax:
                {
                    return CreatePayTaxActionRequirements();
                }
                default:
                {
                    throw new NotSupportedException();
                }
            }
        }

        private static IActionRequirements CreateTransferFromPersonToPersonActionRequirements()
        {
            return new ActionRequirements();
        }

        private static IActionRequirements CreatePayTaxActionRequirements()
        {
            throw new NotImplementedException();
        }
    }
}