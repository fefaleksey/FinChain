using FinChain.Models.Actions;
using RuleChain.State;

namespace RuleChain.Controller
{
    public class RuleChainController : IRuleChainController
    {
        private readonly IState _state;

        private RuleChainController(IState state)
        {
            _state = state;
        }

        public IActionRequirements GetRequirement(ActionId id) => _state.GetRequirement(id);
    }
}