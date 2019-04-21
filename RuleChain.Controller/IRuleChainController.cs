using FinChain.Models.Actions;

namespace RuleChain.Controller
{
    public interface IRuleChainController
    {
        IActionRequirements GetRequirement(ActionId id);
    }
}