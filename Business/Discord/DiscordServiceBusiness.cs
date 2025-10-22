using Business.Contract.Discord;
using System.Text;

namespace Business.Discord
{
    public class DiscordServiceBusiness : IDiscordServiceBusiness
    {
        private readonly string _webHookUri;
        private readonly HttpClient _client;
        private readonly bool IsActivated;


        public DiscordServiceBusiness(string? webHookUri)
        {
            IsActivated = !string.IsNullOrEmpty(webHookUri);

            if (IsActivated)
            {
                _webHookUri = webHookUri;
                _client = new HttpClient();
            }
        }

        public async Task LogAsync(string message)
        {
            try
            {
                if (IsActivated)
                {
                    var payload = new { content = message };
                    var json = System.Text.Json.JsonSerializer.Serialize(payload);
                    var resposta = await _client.PostAsync(_webHookUri, new StringContent(json, Encoding.UTF8, "application/json"));
                    resposta.EnsureSuccessStatusCode();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
