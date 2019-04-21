using Actions;
using FinChain.Models.Actions;

namespace RuleChain.Chain
{
    interface IOLDController
    {
        IActionRequirements GetRequirement(ActionId id);
    }
}