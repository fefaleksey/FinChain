using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotaryNode.Client;
using TransactionPool;
using UserChain.Controller;
using UserChain.Models;

namespace OrderingService
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        private readonly ITransactionsPool<UserChainTransaction> _transactionsPool;
        private readonly INotaryNodeClient _notaryNodeClient;
        private readonly IUserChainController _controller;
        private readonly TimerModule _timer;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
            var chain = new global::UserChain.UserChain();
            _transactionsPool = new TransactionsPool<UserChainTransaction>();
            _notaryNodeClient = new NotaryNodeClient(new HttpClient());
            _controller = new UserChainController(chain);
            _timer = new TimerModule(_transactionsPool, _notaryNodeClient, Configuration, _controller);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton<ITransactionsPool<UserChainTransaction>>(_transactionsPool)
                .AddSingleton<INotaryNodeClient>(_notaryNodeClient)
                .AddSingleton<IConfiguration>(Configuration)
                .AddSingleton<IUserChainController>(_controller);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}