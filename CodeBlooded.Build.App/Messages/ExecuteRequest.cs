using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace CodeBlooded.Build.App.Messages
{
    public class ExecuteRequest
    {
        public int Id { get; set; }

        [JsonPropertyName("Answer")]
        [JsonProperty("Answer")]
        public string Code { get; set; }
        
        
        public TimeSpan TimeLimit { get; set; } 

        public int MemoryLimit { get; set; }
        
        public IReadOnlyList<string> Input { get; set; }
    }
}