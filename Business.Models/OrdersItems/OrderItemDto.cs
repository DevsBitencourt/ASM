using System.Text.Json.Serialization;

namespace Business.Models.OrdersItems
{
    public class OrderItemDto
    {
        [JsonPropertyName("idOrder")]
        public int IdOrder { get; set; }

        [JsonPropertyName("idProduct")]
        public int idProduct { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }
    }
}
