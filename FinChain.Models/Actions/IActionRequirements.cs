using System.Collections.Generic;

namespace FinChain.Models.Actions
{
    public interface IActionRequirements
    {
        RequirementId Id { get; }

        List<ActionType> PeekActions();
        List<ActionType> DequeueActions();
        List<List<ActionType>> GetAllRequirements();
        void AddAction(ActionType action, int step);
        void RemoveAction(int step, int position);
        void Clear();
    }
}