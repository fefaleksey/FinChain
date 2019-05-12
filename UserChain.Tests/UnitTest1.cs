using UserChain.Controller;
using Xunit;

namespace UserChain.Tests
{
    public class UnitTest1
    {
        private readonly UserChain _chain;
        private readonly State _state = new State();
        private readonly UserChainController _controller;

        public UnitTest1()
        {
            _chain = new UserChain();
            _controller = new UserChainController(_chain);
        }
        
        [Fact]
        public void CompileTest()
        {
            var code = System.IO.File.ReadAllText("../../../HelloWorld.cs");
        }
    }
}