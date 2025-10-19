using System.Text.Json.Serialization;

namespace Business.Models.Orders.Create
{
    public class CreateOrderRespondeDto
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
        /// Status do pedido, [0] Em aberto, [1] Pago
        /// </summary>
        [JsonPropertyName("status")]
        public int Status { get; set; }

        /// <summary>
        /// Data de criação do pedido
        /// </summary>
        [JsonPropertyName("dateOfCreation")]
        public DateTime Date { get; set; }
    }
}
