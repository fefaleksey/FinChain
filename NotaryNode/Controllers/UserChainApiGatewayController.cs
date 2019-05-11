using FinChain.Models.Actions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UserChain.Controller;
using UserChain.Models;

namespace NotaryNode.Controllers
{
    [Route("api/[controller]")]    
    [ApiController]
    public class UserChainApiGatewayController : ControllerBase
    {
        private readonly IUserChainController _controller;
        public UserChainApiGatewayController(IUserChainController controller)
        {
            _controller = controller;
        }
        
        [HttpPost, Route("addBlock")]
        public void AddBlock([FromBody] JObject jsonBlock) //dynamic
        {
            var block = jsonBlock.ToObject<UserChainBlock>(new JsonSerializer()
            {
                TypeNameHandling = TypeNameHandling.All
            });
            
            _controller.CommitBlock(block);
        }
    }
}