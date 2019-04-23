using System.Collections.Generic;
using FinChain.Models.Actions;

namespace Actions
{
    public class TransferFromPersonToPersonActionRequirements : IActionRequirements
    {
        public RequirementId Id { get; } = new RequirementId();
        private List<List<IAction>> LinksQueue { get; set; }

        public TransferFromPersonToPersonActionRequirements()
        {
            LinksQueue = new List<List<IAction>>();
        }

        public void AddAction(IAction action, int step) => LinksQueue[step].Add(action);
        
        public void RemoveAction(int step, int position) => LinksQueue[step].RemoveAt(position);
        
        public List<IAction> PeekActions() => LinksQueue[0];
        
        public List<List<IAction>> GetAllRequirements() => LinksQueue;

        public List<IAction> DequeueActions()
        {
            var actions = PeekActions();
            const int step = 0;
            const int position = 0;
            RemoveAction(step, position);
            return actions;
        }
    }
}