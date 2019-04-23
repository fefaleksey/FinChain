using System.Collections.Generic;

namespace FinChain.Models.Actions
{
    public interface IActionRequirements
    {
        RequirementId Id { get; }

        List<IAction> PeekActions();
        List<IAction> DequeueActions();
        List<List<IAction>> GetAllRequirements();
        void AddAction(IAction action, int step);
        void RemoveAction(int step, int position);
    }
}