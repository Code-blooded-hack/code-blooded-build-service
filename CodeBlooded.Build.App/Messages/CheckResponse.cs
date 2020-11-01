using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CodeBlooded.Build.App.Messages
{
    public class CheckResponse
    {
        [JsonPropertyName("id")]
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("results")]
        [JsonProperty("results")]
        public IReadOnlyList<TestResultResponse> Results { get; set; }
    }
}