using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RuleChain.Controller;
using UserChain.Controller;

namespace NotaryNode
{
    public class Startup
    {
        private readonly IRuleChainController _ruleChainController;
        private readonly IUserChainController _userChainController;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
            var ruleChain = new global::RuleChain.RuleChain();
            _ruleChainController = new RuleChainController(ruleChain);

            var userChain = new UserChain.UserChain();
            _userChainController = new UserChainController(userChain);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton<IRuleChainController>(_ruleChainController)
                .AddSingleton<IUserChainController>(_userChainController)
                .AddSingleton<IConfiguration>(Configuration);
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