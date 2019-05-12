using System.Threading;
using Microsoft.Extensions.Configuration;
using NotaryNode.Client;
using TransactionPool;
using UserChain.Controller;
using UserChain.Models;

namespace OrderingService
{
    public class TimerModule
    {
        private static Timer _timer;
        private const long Interval = 10000; //10 sec
        private static readonly object SyncLock = new object();
        private readonly ITransactionsPool<UserChainTransaction> _transactionsPool;
        private readonly INotaryNodeClient _notaryNodeClient;
        private readonly IConfiguration _configuration;
        private readonly IUserChainController _controller;

        public TimerModule(ITransactionsPool<UserChainTransaction> transactionsPool, INotaryNodeClient notaryNodeClient, 
            IConfiguration configuration, IUserChainController controller)
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
                var block = new UserChainBlock(transactions, _controller.GetLastBlockHash());
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