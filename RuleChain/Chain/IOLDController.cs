using Actions;

namespace RuleChain.Chain
{
    interface IOLDController
    {
        IRequirements GetRequirement(ActionId id);
    }
}