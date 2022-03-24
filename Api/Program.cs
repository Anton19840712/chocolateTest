using Api.GraphQl;
using Api.Database;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddSingleton<Repository>()
    //.AddAuthentication().Services // Configure your Authentication here
    //.AddAuthorization(o => o.AddPolicy("Librarian", p => p.RequireAssertion(_ => false)))
    .AddGraphQLServer()
    .AddMutationType<Mutation>()
    .AddQueryType<Query>()
    //.AddAuthorization()
    .UseField<DomainExceptionMiddleware>();

var app = builder.Build();
app.MapGraphQL();
app.Run();