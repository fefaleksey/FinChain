using System.Collections.Generic;

namespace FinChain.Models.Actions
{
    public interface IActionRequirements
    {
        ActionId RequirementsId { get; }

        List<ActionId> PeekActions();
        List<ActionId> DequeueActions();
        List<List<ActionId>> GetAllRequirements();
        void AddAction(ActionId actionId, int step);
        void RemoveAction(int step, int position);
    }
}