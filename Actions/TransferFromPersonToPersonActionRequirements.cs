using System.Collections.Generic;
using FinChain.Models.Actions;

namespace Actions
{
    public class TransferFromPersonToPersonActionRequirements : IActionRequirements
    {
        public ActionId RequirementsId { get; } = new ActionId();
        private List<List<ActionId>> LinksQueue { get; set; }

        public TransferFromPersonToPersonActionRequirements()
        {
            LinksQueue = new List<List<ActionId>>();
        }

        public void AddAction(ActionId actionId, int step) => LinksQueue[step].Add(actionId);
        
        public void RemoveAction(int step, int position) => LinksQueue[step].RemoveAt(position);
        
        public List<ActionId> PeekActions() => LinksQueue[0];
        
        public List<List<ActionId>> GetAllRequirements() => LinksQueue;

        public List<ActionId> DequeueActions()
        {
            var actions = PeekActions();
            RemoveAction(0,0);
            return actions;
        }
    }
}