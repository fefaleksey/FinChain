using System.Threading;
using Microsoft.Extensions.Configuration;
using NotaryNode.Client;
using RuleChain.Controller;
using RuleChain.Models;
using TransactionPool;

namespace Government
{
    public class TimerModule
    {
        private static Timer _timer;
        private const long Interval = 10000; //10 sec
        private static readonly object SyncLock = new object();
        private readonly ITransactionsPool<RuleTransaction> _transactionsPool;
        private readonly INotaryNodeClient _notaryNodeClient;
        private readonly IConfiguration _configuration;
        private readonly IRuleChainController _controller;

        public TimerModule(ITransactionsPool<RuleTransaction> transactionsPool, INotaryNodeClient notaryNodeClient, 
            IConfiguration configuration, IRuleChainController controller)
        {
            _transactionsPool = transactionsPool;
            _notaryNodeClient = notaryNodeClient;
            _configuration = configuration;
            _controller = controller;
            _timer = new Timer(new TimerCallback(BroadcastBlock), null, 0, Interval);
        }

        private void BroadcastBlock(object obj)
        {
            lock (SyncLock)
            {
                var transactions = _transactionsPool.GetAll();
                if (transactions.Count == 0)
                {
                    return;
                }
                var urls = _configuration.GetSection("NotaryNodes").Get<string[]>();
                var block = new RuleBlock(transactions, _controller.GetLastBlockHash());
                foreach (var url in urls)
                {
                    _notaryNodeClient.SendBlock(url, block);
                }
            }
        }
            
        public void Dispose()
        { }
    }
}