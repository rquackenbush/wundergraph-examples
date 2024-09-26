﻿using ChildSubgraph.Data;
using ChildSubgraph.Types;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddGraphQLServer()
    .AddApolloFederation()
    .RegisterService<ChildRepository>()
    .AddQueryType<Query>();

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

builder.Services.AddSingleton<ChildRepository>();

var app = builder.Build();

app.UseCors();

app.MapGraphQL();

app.Run();
