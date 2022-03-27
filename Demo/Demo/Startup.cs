using Demo.Data;
using Demo.DataBaseContexts;
using Demo.Infrastructure.Configuration.Mapping;
using Demo.Repositories.PersonRepository;
using Demo.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Demo
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

            services
                .AddGraphQLServer()
                    .AddQueryType<PersonQuery>()
                    .AddMutationType<Mutation>()
                    .AddType<PersonType>()
                    .AddFiltering()
                    .AddSorting()
                    .AddInMemorySubscriptions()
                    .AddDataLoader<PersonDataLoader>()
                ;

            services
                .AddPooledDbContextFactory<PersonContext>
                    (x =>
                        x.UseSqlServer(Configuration.GetConnectionString("PersonContext")));

            services.AddMapping();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
