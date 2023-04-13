using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add Ocelot services

builder.Services.AddOcelot(builder.Configuration);

// Add Ocelot.json configuration file
builder.Configuration.AddJsonFile("ocelot.json");


var app = builder.Build();

// Use Ocelot middleware
app.UseOcelot().Wait();

app.Run();
