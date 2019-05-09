using System;
using FinChain.Models.Actions;
using NotaryNode.Client;
using RuleChain.Controller;

namespace Actions
{
    public class ActionBuilder
    {
        private readonly IRuleChainController _controller;
        private readonly INotaryNodeClient _client;
        
        public ActionBuilder(IRuleChainController controller, INotaryNodeClient client)
        {
            _controller = controller;
            _client = client;
        }

        public IAction Create(ActionType type, string notaryNodeUri)
        {
            switch (type)
            {
                case ActionType.TransferFromPersonToPerson:
                {
                    return CreateTransferFromPersonToPersonAction(notaryNodeUri);
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

        private IAction CreateTransferFromPersonToPersonAction(string notaryNodeUri)
        {
            var task = _client.GetRequirements(notaryNodeUri, ActionType.TransferFromPersonToPerson);
            var actionRequirements = task.Result;
            return new TransferFromPersonToPersonAction(actionRequirements);
        }

        private IAction CreatePayTaxAction()
        {
            return new PayTaxAction();
        }
    }
}