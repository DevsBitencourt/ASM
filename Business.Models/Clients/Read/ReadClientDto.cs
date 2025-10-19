using System.Text.Json.Serialization;

namespace Business.Models.Clients.Read
{
    public class ReadClientDto : ClientDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
