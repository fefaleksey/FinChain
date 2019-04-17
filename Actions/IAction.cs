using System.Collections.Generic;
using UserChain.Accounts;

namespace Actions
{
    public interface IAction
    {
        IRequirements Requirements { get; }

        bool IsActive { get; }

        void Execute(params object[] list);
    }
}