using System;
using System.Collections.Generic;


namespace CodeBlooded.Build.App.Messages
{
    public class CheckRequest
    {
        public int CheckId { get; set; }
        
        public string Language { get; set; }
        
        public string StudentCode { get; set; }
        
        public string TutorCode { get; set; }
        
        public IReadOnlyList<string> Input { get; }
    }
}