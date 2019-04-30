using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using NotaryNode.Client;
using RuleChain;
using RuleChain.Controller;
using RuleChain.TransactionsPool;


namespace Government
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private readonly HttpClient _client = new HttpClient();
        private readonly NotaryNodeClient _notaryNodeClient;
        private readonly RuleTransactionsPool _transactionsPool;
        private readonly TimerModule _timer;
        private readonly global::RuleChain.RuleChain _chain;
        private readonly IRuleChainController _controller;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _notaryNodeClient = new NotaryNodeClient(_client);
            _transactionsPool = new RuleTransactionsPool();
            _chain = new global::RuleChain.RuleChain();
            _controller = new RuleChainController(_chain);
            _timer = new TimerModule(_transactionsPool, _notaryNodeClient, Configuration, _controller);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton<INotaryNodeClient>(_notaryNodeClient)
                .AddSingleton<IRuleTransactionsPool>(_transactionsPool)
                .AddSingleton<TimerModule>(_timer)
                .AddSingleton<IRuleChainController>(_controller)
                .AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Version = "2.0"}); });
            
//            services.AddSingleton<INotaryNodeClient>(_ => new NotaryNodeClient(_client))
//                .AddSingleton<IRuleTransactionsPool>(_ => new RuleTransactionsPool())
//                .AddSingleton<TimerModule>(_ => new TimerModule())
//                .AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Version = "2.0"}); });
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

            app.UseHttpsRedirection()
                .UseMvc()
                .UseSwagger()
                .UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
        }
    }
}