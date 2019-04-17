using System;
using System.Collections.Generic;

namespace Actions
{
    public interface IRequirements
    {
        Guid Id { get; }

        List<IAction> PeekActions();
        List<IAction> DequeueActions();
        List<List<IAction>> GetAllRequirements();
        void AddAction(IAction action, int step);
        void RemoveAction(int step, int position);
    }
}