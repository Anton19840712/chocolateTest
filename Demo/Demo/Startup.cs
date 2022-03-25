using Demo.Data;
using Demo.GraphQl;
using Demo.Types;
using HotChocolate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Demo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddPooledDbContextFactory<PersonContext>(
                    (s, o) => o
                        .UseSqlServer(@"Server=GRIDUSHKO-AA\\SQLEXPRESS01;Database=Sales;Trusted_Connection=True;MultipleActiveResultSets=true")
                        .UseLoggerFactory(s.GetRequiredService<ILoggerFactory>()))
                .AddGraphQLServer()
                    .AddQueryType<Query>()
                    .AddMutationType<Mutation>()
                    .AddType<PersonType>()
                    .AddFiltering()
                    .AddSorting()
                    .AddInMemorySubscriptions()
                    .AddDataLoader<PersonDataLoader>();
            services.AddDbContext<PersonContext>();
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
