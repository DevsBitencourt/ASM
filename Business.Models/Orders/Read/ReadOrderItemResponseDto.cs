using System.Text.Json.Serialization;


namespace Business.Models.Orders.Read
{
    public class ReadOrderItemResponseDto
    {
        [JsonPropertyName("sequence")]
        public int Sequence { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("productCode")]
        public int ProductCode { get; set; }

        [JsonPropertyName("productName")]
        public string ProductName { get; set; }

        [JsonPropertyName("productPrice")]
        public decimal ProductPrice { get; set; }

        [JsonPropertyName("subTotal")]
        public decimal SubTotal
        {
            get
            {
                return Amount * ProductPrice;
            }
        }
    }
}
