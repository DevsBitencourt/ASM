using System.Text.Json.Serialization;

namespace Business.Models.Clients
{
    public class ClientDto
    {
        #region Properties

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("document")]
        public string Document { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("telephone")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Telephone { get; set; }

        #endregion
    }
}
