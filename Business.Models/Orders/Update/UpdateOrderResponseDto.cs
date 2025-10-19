using System.Text.Json.Serialization;

namespace Business.Models.Orders.Update
{
    public class UpdateOrderResponseDto
    {
        /// <summary>
        /// Identificador do pedido
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Identificador do cliente
        /// </summary>
        [JsonPropertyName("idClient")]
        public int IdClient { get; set; }

        /// <summary>
        /// Status do pedido, [0] Em Aberto, [1] Pago
        /// </summary>
        [JsonPropertyName("status")]
        public int Status { get; set; }
    }
}
