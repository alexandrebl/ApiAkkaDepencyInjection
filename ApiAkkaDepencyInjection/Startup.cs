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
using Serilog;
using ApiAkkaDepencyInjection.Application.Middlewares;

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

            services.AddSwaggerService();

            services.AddTransient<IQueryServices, QueryServices>();
            services.AddSingleton<IBookRepository>(new BookRepository());

            services.AddSingleton(ActorSystem.Create("libraryActorSystem"));

            services.AddSingleton<CustomProviders.BookActorProvider>(provider =>
            {
                var actorSystem = provider.GetService<ActorSystem>();
                var bookActor = actorSystem.ActorOf(
                    Props.Create(() => new BookQueryActor(
                        provider.GetService<IBookRepository>())));
                return () => bookActor;
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerApp("docs");

            app.UseSerilogRequestLogging();

            app.UseMvc();
        }
    }
}