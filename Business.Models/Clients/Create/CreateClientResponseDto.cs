using System.Text.Json.Serialization;

namespace Business.Models.Clients.Create
{
    public class CreateClientResponseDto : ClientDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
