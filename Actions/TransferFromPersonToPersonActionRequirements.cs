using System.Collections.Generic;
using FinChain.Models.Actions;

namespace Actions
{
    public class TransferFromPersonToPersonActionRequirements : IActionRequirements
    {
        public RequirementId Id { get; } = new RequirementId();
        private List<List<ActionType>> Requirements { get; set; }

        public TransferFromPersonToPersonActionRequirements()
        {
            Requirements = new List<List<ActionType>>();
        }

        public void AddAction(ActionType action, int step)
        {
            while (Requirements.Count <= step)
            {
                Requirements.Add(new List<ActionType>());
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

        public List<ActionType> PeekActions() => Requirements[0];
        
        public List<List<ActionType>> GetAllRequirements() => Requirements;

        public List<ActionType> DequeueActions()
        {
            var actions = PeekActions();
            const int step = 0;
            const int position = 0;
            RemoveAction(step, position);
            return actions;
        }
    }
}