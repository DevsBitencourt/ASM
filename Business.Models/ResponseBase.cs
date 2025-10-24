using System.Text.Json.Serialization;

namespace Business.Models
{
    /// <summary>
    /// Retorno padrão
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public sealed class ResponseBase<TEntity>
    {
        /// <summary>
        /// Dados a serem retornados
        /// </summary>
        [JsonPropertyName("data")]
        public TEntity? Data { get; set; }

        /// <summary>
        /// Erros capturados
        /// </summary>
        [JsonPropertyName("errors")]
        public object? Errors { get; set; }
    }
}
