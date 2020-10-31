using System.Collections.Generic;
using Newtonsoft.Json;


namespace CodeBlooded.Build.Messages
{
    public class CheckRequestMessage
    {
        [JsonProperty("id")]
        public string CheckId { get; set; }
        
        [JsonProperty("language")]
        public string Language { get; set; }
        
        [JsonProperty("answer")]
        public IReadOnlyList<string> StudentCode { get; set; }
        
        [JsonProperty("reference_answer")]
        public IReadOnlyList<string> TutorCode { get; set; }
        
        [JsonProperty("input")]
        public IReadOnlyList<string> Input { get; set; }
    }
}