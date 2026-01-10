using Microsoft.AspNetCore.Authentication.JwtBearer;
using DataProviders;
using DataProviders.Interfaces;
using Microsoft.Azure.Cosmos;
using Services;
using Services.Interfaces;
using Storage.Repositories;
using Storage.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication()
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:5001";
        options.TokenValidationParameters.ValidateAudience = false;
        // do not remove otherwise get ???????????????????
        // Bearer error="invalid_token", error_description="The issuer 'https://localhost:5001' is invalid" ???????
        options.BackchannelHttpHandler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//cosmos
var cosmosConnectionString = builder.Configuration.GetValue<string>("ConnectionStrings:CosmosConnectionString") ?? throw new Exception("CosmosConnectionString not found");
builder.Services.AddScoped<CosmosClient>(sp => new CosmosClient(cosmosConnectionString));
// services
builder.Services.AddScoped<IStockPriceService, StockPriceService>();
// repositories
builder.Services.AddScoped<IStockPriceRepository, StockPriceRepository>();
// data providers
builder.Services.AddScoped<IFMPDataProvider, FMPDataProvider>();
// http client
builder.Services.AddScoped<HttpClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
