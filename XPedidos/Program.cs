using Scalar.AspNetCore;
using XPedidos.Infrastructure.DI;
using XPedidos.Infrastructure.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

RepositoryServices.Configure(builder.Services);
XPedidosServices.Configure(builder.Services);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.MapOpenApi();

app.MapScalarApiReference("/api-docs", options =>
{
    options
        .WithTitle("Pedidos API")
        .WithTheme(ScalarTheme.Solarized)
        .HideDocumentDownload()
        .HideModels();
});

app.UseMiddleware<DiscordMiddleware>();

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
