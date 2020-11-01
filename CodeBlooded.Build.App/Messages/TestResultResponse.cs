using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CodeBlooded.Build.App.Messages
{
    public class TestResultResponse
    {
        [JsonPropertyName("input")]
        [JsonProperty("input")]
        public string Input { get; set; }

        [JsonPropertyName("output")]
        [JsonProperty("output")]
        public string Output { get; set; }

        [JsonPropertyName("status")]
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}