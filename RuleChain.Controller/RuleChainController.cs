using Actions;
using RuleChain.Chain;

namespace RuleChain.Controller
{
    public class RuleChainController : IRuleChainController
    {
        private readonly IState _state;

        private RuleChainController(IState state)
        {
            _state = state;
        }

        public IRequirements GetRequirement(ActionId id) => _state.GetRequirement(id);
    }
}