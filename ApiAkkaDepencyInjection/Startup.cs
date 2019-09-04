using Akka.Actor;
using ApiAkkaDepencyInjection.CrossCuting.Providers;
using ApiAkkaDepencyInjection.Repository;
using ApiAkkaDepencyInjection.Repository.Interfaces;
using ApiAkkaDepencyInjection.Services;
using ApiAkkaDepencyInjection.Services.Actors;
using ApiAkkaDepencyInjection.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiAkkaDepencyInjection.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddTransient<IQueryServices, QueryServices>();
            services.AddSingleton<IDrawRepository, DrawRepository>();

            services.AddSingleton<ActorSystem>(ActorSystem.Create("businessActorSystem"));

            services.AddSingleton<AkkaProviders.DrawActorProvider>(provider =>
            {
                var actorSystem = provider.GetService<ActorSystem>();
                var booksManagerActor = actorSystem.ActorOf(
                    Props.Create(() => new DrawQueryActor(new DrawRepository())));
                return () => booksManagerActor;
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}