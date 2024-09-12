using ApolloFederationRepro.Types;
using ParentSubgraph.Data;
using ParentSubgraph.Types;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .RegisterService<ParentRepository>()
    .AddApolloFederation();

builder
   .Services
   .AddCors(options =>
   {
       options.AddDefaultPolicy(builder =>
       {
           builder
               .WithOrigins("https://studio.apollographql.com")
               .AllowAnyHeader()
               .AllowAnyMethod();
       });
   });

builder.Services.AddSingleton<ParentRepository>();

var app = builder.Build();

app.UseCors();

app.MapGraphQL();

app.Run();
