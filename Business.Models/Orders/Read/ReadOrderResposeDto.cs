using System.Text.Json.Serialization;

namespace Business.Models.Orders.Read
{
    public class ReadOrderResposeDto
    {
        /// <summary>
        /// Identificador pedido
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Data de criação do pedido
        /// </summary>
        [JsonPropertyName("dateOfCreation")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Status do pedido [0] Em aberto, [1] Pago
        /// </summary>
        [JsonPropertyName("status")]
        public int Status { get; set; }

        /// <summary>
        /// Nome do cliente
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Documento de identificação do cliente
        /// </summary>
        [JsonPropertyName("document")]
        public string Document { get; set; }

        /// <summary>
        /// Valor total do pedido
        /// </summary>
        [JsonPropertyName("total")]
        public decimal Total { get; set; }

        [JsonPropertyName("items")]
        public IEnumerable<ReadOrderItemResponseDto>? Items { get; set; }
    }
}
