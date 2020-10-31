using System.Collections.Generic;
using Newtonsoft.Json;

namespace CodeBlooded.Build.Messages
{
    public class CheckResponseMessage
    {
        [JsonProperty("id")]
        public string CheckId { get; set; }

        [JsonProperty("answer")]
        public IReadOnlyList<string> Answer { get; set; }
        
        [JsonProperty("running_time")]
        public int ExecutionTime { get; set; }
        
        [JsonProperty("memory_use")]
        public int MemoryUsage { get; set; }
        
        [JsonProperty("tests")]
        public IReadOnlyList<string> Results { get; set; }
    }
}