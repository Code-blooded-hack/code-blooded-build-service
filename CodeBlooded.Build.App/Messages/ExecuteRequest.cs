using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace CodeBlooded.Build.App.Messages
{
    public class ExecuteRequest
    {
        public int Id { get; set; }

        [JsonPropertyName("Answer")]
        public string Code { get; set; }

        public IReadOnlyList<string> Input { get; set; }
    }
}