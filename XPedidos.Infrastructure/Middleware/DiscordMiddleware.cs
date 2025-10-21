using Business.Contract.Discord;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace XPedidos.Infrastructure.Middleware
{
    public class DiscordMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDiscordServiceBusiness _logService;

        public DiscordMiddleware(RequestDelegate next, IDiscordServiceBusiness logService)
        {
            _next = next;
            _logService = logService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Exemplo: logando entrada e saída
            await _logService.LogAsync($"[Request] {context.Request.Method} {context.Request.Path}");
            await _next(context);

            var sb = new StringBuilder();
            sb
                .AppendLine($"[StatusCode] {context.Response.StatusCode}")
                .AppendLine($"[Request finished] {context.Request.Method} {context.Request.Path}");

            await _logService.LogAsync(sb.ToString());
        }
    }
}