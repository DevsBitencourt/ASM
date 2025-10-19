using System.Text.Json.Serialization;

namespace Business.Models.Products.Create
{
    public class CreateProductResponseDto
    {
        /// <summary>
        /// Identificador do produto
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

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
