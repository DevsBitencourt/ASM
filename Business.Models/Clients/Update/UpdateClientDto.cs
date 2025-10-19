using System.Text.Json.Serialization;

namespace Business.Models.Clients.Update
{
    public class UpdateClientDto : ClientDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
