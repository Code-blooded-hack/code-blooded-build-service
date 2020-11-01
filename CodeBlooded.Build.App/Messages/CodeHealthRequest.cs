using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CodeBlooded.Build.App.Messages
{
    public class CodeHealthRequest
    {
        [JsonPropertyName("id")]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonPropertyName("answer")]
        [JsonProperty("answer")]
        public string Code { get; set; }

        [JsonPropertyName("language")]
        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonPropertyName("tests")]
        [JsonProperty("tests")]
        public IReadOnlyList<InputOutputPair> Tests { get; set; }
    }
}