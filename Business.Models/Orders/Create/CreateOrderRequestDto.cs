using System.Text.Json.Serialization;

namespace Business.Models.Orders.Create
{
    public sealed class CreateOrderRequestDto
    {
        /// <summary>
        /// Identificador do cliente
        /// </summary>
        [JsonPropertyName("idClient")]
        public int IdClient { get; set; }
    }
}
