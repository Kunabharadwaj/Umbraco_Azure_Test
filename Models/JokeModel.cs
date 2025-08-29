using System.Text.Json.Serialization;

namespace Umbraco_Azure_test.Models
{
    public class JokeModel
    {
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
