using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace CodeBlooded.Build.App.Messages
{
    public class CheckRequest
    {
        [JsonPropertyName("id")]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonPropertyName("language")]
        [JsonProperty("language")]
        public string Language { get; set; }
        
        [JsonPropertyName("answer")]
        [JsonProperty("answer")]
        public string Code { get; set; }
        
        [JsonPropertyName("timeLimit")]
        [JsonProperty("timeLimit")]
        public long TimeLimit { get; set; }

        [JsonPropertyName("memoryLimit")]
        [JsonProperty("memoryLimit")]
        public int MemoryLimit { get; set; }
        
        [JsonPropertyName("tests")]
        [JsonProperty("tests")]
        public IReadOnlyList<string> Tests { get; set; }
    }
}