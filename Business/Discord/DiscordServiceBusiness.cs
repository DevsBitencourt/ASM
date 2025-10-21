using Business.Contract.Discord;
using System.Text;

namespace Business.Discord
{
    public class DiscordServiceBusiness : IDiscordServiceBusiness
    {
        private readonly string _webHookUri;
        private readonly HttpClient _client;

        public DiscordServiceBusiness(string webHookUri)
        {
            _webHookUri = webHookUri;
            _client = new HttpClient();
        }

        public async Task LogAsync(string message)
        {
            try
            {
                var payload = new { content = message };
                var json = System.Text.Json.JsonSerializer.Serialize(payload);
                var resposta = await _client.PostAsync(_webHookUri, new StringContent(json, Encoding.UTF8, "application/json"));
                resposta.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
            }
        }
    }
}
