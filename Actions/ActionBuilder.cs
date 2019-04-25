using System;
using FinChain.Models.Actions;
using RuleChain.Controller;

namespace Actions
{
    public class ActionBuilder
    {
        private readonly IRuleChainController _controller;

        public ActionBuilder(IRuleChainController controller)
        {
            _controller = controller;
        }

        public IAction Create(ActionType type)
        {
            switch (type)
            {
                case ActionType.TransferFromPersonToPerson:
                {
                    return CreateTransferFromPersonToPersonAction();
                }
                case ActionType.PayTax:
                {
                    return CreatePayTaxAction();
                }
                default:
                {
                    throw new NotSupportedException();
                }
            }
        }

        private IAction CreateTransferFromPersonToPersonAction()
        {
            return new TransferFromPersonToPersonAction(_controller);
        }

        private IAction CreatePayTaxAction()
        {
            return new PayTaxAction();
        }
    }
}