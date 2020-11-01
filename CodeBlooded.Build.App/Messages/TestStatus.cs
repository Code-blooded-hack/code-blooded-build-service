namespace CodeBlooded.Build.App.Messages
{
    public enum TestStatus
    {
        Ok,
        TimeLimitError,
        MemoryLimitError,
        RuntimeError,
        CompilationError,
        SecurityViolationError
    }
}