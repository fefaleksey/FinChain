using System;
using System.Collections.Generic;

namespace Actions
{
    public class TransferFromPersonToPersonRequirements : IRequirements
    {
        public Guid Id { get; }
        private List<List<IAction>> LinksQueue { get; set; }

        public TransferFromPersonToPersonRequirements()
        {
            LinksQueue = new List<List<IAction>>();
        }

        public void AddAction(IAction action, int step)
        {
            LinksQueue[step].Add(action);
        }

        public void RemoveAction(int step, int position)
        {
            LinksQueue[step].RemoveAt(position);
        }
        
        public List<IAction> PeekActions()
        {
            return LinksQueue[0];
        }

        public List<IAction> DequeueActions()
        {
            var actions = PeekActions();
            RemoveAction(0,0);
            return actions;
        }

        public List<List<IAction>> GetAllRequirements()
        {
            return LinksQueue;
        }
    }
}