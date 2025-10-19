using System.Text.Json.Serialization;

namespace Business.Models.Products.Create
{
    public class CreateProductsRequestDto
    {
        /// <summary>
        /// Nome do produto
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Quantidade
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Preço
        /// </summary>
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
}
