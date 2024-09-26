﻿using ApolloFederationRepro.Types;
using ParentSubgraph.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddApolloFederation()
    .AddQueryType<Query>()
    .RegisterService<ParentRepository>();
    

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
