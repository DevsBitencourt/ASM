using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Scalar.AspNetCore;
using System.Diagnostics;
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
        .HideClientButton()
        .HideModels();
});


app.Lifetime.ApplicationStarted.Register(() =>
{
    var addresses = app.Services.GetRequiredService<IServer>()
        .Features.Get<IServerAddressesFeature>();

    var isKestrelDirect = addresses?.Addresses.Any() == true;
    var isRunningOnIIS = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("ASPNETCORE_PORT"));

    if (isKestrelDirect && !isRunningOnIIS)
    {
        var url = addresses.Addresses.First();
        OpenBrowser($"{url}/api-docs/");
    }
});

app.UseMiddleware<DiscordMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


static void OpenBrowser(string url)
{
    try
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        });
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Não foi possível abrir o navegador: {ex.Message}");
    }
}