using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UserChain;
using UserChain.Controller;
using UserChain.Models;

namespace NotaryNode.Controllers
{
    [Route("api/[controller]")]    
    [ApiController]
    public class UserChainApiGatewayController : ControllerBase
    {
        private readonly IUserChainController _controller;
        private readonly IConfiguration _configuration;
        public UserChainApiGatewayController(IUserChainController controller, IConfiguration configuration)
        {
            _controller = controller;
            _configuration = configuration;
        }
        
        [HttpPost, Route("addBlock")]
        public void AddBlock([FromBody] JObject jsonBlock) //dynamic
        {
            var block = jsonBlock.ToObject<UserChainBlock>(new JsonSerializer()
            {
                TypeNameHandling = TypeNameHandling.All
            });

            var isCorrect = UserChainVerifier.CheckCorrectness(block);
            if (isCorrect)
            {
                _controller.CommitBlock(block);
            }
        }
    }
}