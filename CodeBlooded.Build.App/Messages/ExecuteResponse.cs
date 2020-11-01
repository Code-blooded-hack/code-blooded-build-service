using System;
using System.Collections.Generic;


namespace CodeBlooded.Build.App.Messages
{
    public class ExecuteResponse
    {
        public int Id { get; set; }

        public TimeSpan ExecutionTime { get; set; }

        public int MemoryUsage { get; set; }

        public List<TestResult> Tests { get; set; }
    }
}