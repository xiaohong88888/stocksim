using Microsoft.Data.SqlClient;
using TradeApi.Repositories;
using TradeApi.Repositories.Interfaces;
using TradeApi.Services;
using TradeApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using TradeApi;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IAuthorizationHandler, StocksimAuthHandler>();

builder.Services.AddAuthentication()
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:5001";
        options.TokenValidationParameters.ValidateAudience = false;
        options.MapInboundClaims = false;

        // do not remove otherwise get ???????????????????
        // Bearer error="invalid_token", error_description="The issuer 'https://localhost:5001' is invalid" ???????
        options.BackchannelHttpHandler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };
    });

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("TradePolicy", policy =>
    {
        policy.Requirements.Add(new StocksimAuthRequirement("stocksim.tradeapi", "Trader"));
    });

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Register SqlConnection
var connectionString = builder.Configuration.GetValue<string>("ConnectionStrings:DefaultConnection")
    ?? throw new Exception("SqlConnectionString not found");
builder.Services.AddScoped(sp => new SqlConnection(connectionString));

builder.Services.AddScoped<ITradeService, TradeService>();

builder.Services.AddScoped<ITradeRepository, TradeRepository>();
builder.Services.AddScoped<IBalanceRepository, BalanceRepository>();

// self-signed certificate not trusted?????
builder.Services.AddHttpClient("isClient")
    .ConfigurePrimaryHttpMessageHandler(sp =>
    {
        return new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
