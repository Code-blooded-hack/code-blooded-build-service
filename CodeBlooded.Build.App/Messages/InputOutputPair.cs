using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace CodeBlooded.Build.App.Messages
{
    public struct InputOutputPair
    {
        [JsonPropertyName("input")]
        [JsonProperty("input")]
        public string Input { get; set; }
        
        [JsonPropertyName("output")]
        [JsonProperty("output")]
        public string Output { get; set; }
    }
}