using System.Threading.Tasks;
using FinChain.Models.Actions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RuleChain.Controller;
using RuleChain.Models;

namespace NotaryNode.Controllers
{
    [Route("api/[controller]")]    
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IRuleChainController _controller;
        public TransactionsController(IRuleChainController controller)
        {
            _controller = controller;
        }
        
        [HttpPost, Route("addBlock")]
        public void AddBlock([FromBody] JObject jsonBlock) //dynamic
        {
            var block = jsonBlock.ToObject<RuleBlock>(new JsonSerializer()
            {
                TypeNameHandling = TypeNameHandling.All
            });
            
            _controller.CommitBlock(block);
        }
        
        [HttpGet, Route("getRequirements/{action}")]
        public ActionResult<IActionRequirements> GetRequirements(ActionType action) //dynamic
        {
            var actionResult = new ActionResult<IActionRequirements>(_controller.GetRequirements(action));
            return actionResult;
        }
    }
}