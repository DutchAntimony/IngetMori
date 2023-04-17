using IngetMori.Api;
using IngetMori.Application;
using IngetMori.Infrastructure;
using IngetMori.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddPersistence(builder.Configuration)
    .AddFirebaseAuth(builder.Configuration);

builder.Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options => 
        options.SuppressModelStateInvalidFilter = true);

builder.Services
    .AddSwagger();

var app = builder.Build();

await app.Configure();

app.Run();