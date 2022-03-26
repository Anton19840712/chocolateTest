using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GraphiQl;
using GraphQL.Server;
using GraphQL.Types;
using GraphQlBasicApi.Data;
using GraphQlBasicApi.Interfaces;
using GraphQlBasicApi.Mutation;
using GraphQlBasicApi.Query;
using GraphQlBasicApi.Schema;
using GraphQlBasicApi.Services;
using GraphQlBasicApi.Type;
using Microsoft.EntityFrameworkCore;

namespace GraphQlBasicApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IPerson, PersonService>();
            services.AddTransient<PersonType>();
            services.AddTransient<PersonQuery>();
            services.AddTransient<PersonMutation>();
            services.AddTransient<ISchema, PersonSchema>();

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = false;
            }).AddSystemTextJson();



            services
                .AddDbContext<PersonDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("PersonContext")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //dbContext.Database.EnsureCreated();
            app.UseGraphiQl("/graphql");
            app.UseGraphQL<ISchema>();
        }
    }
}