using System.Collections.Generic;

namespace FinChain.Models.Actions
{
    public class ActionRequirements : IActionRequirements
    {
        private List<List<IAction>> Requirements { get; set; }

        public ActionRequirements()
        {
            Requirements = new List<List<IAction>>();
        }

        public void AddAction(IAction action, int step)
        {
            while (Requirements.Count <= step)
            {
                Requirements.Add(new List<IAction>());
            }
            
            Requirements[step].Add(action);
        }

        public void RemoveAction(int step, int position)
        {
            if (Requirements.Count <= step)
            {
                return;
            }

            if (Requirements[step].Count <= position)
            {
                return;
            }
            Requirements[step].RemoveAt(position);
        }

        public void Clear()
        {
            Requirements.Clear();
        }

        public List<IAction> PeekActions() => Requirements[0];
        
        public List<List<IAction>> GetAllRequirements() => Requirements;

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