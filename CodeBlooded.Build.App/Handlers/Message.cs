namespace CodeBlooded.Build.App.Handlers
{
    public readonly struct Message<T> where T : class
    {
        public Message(T value, string routingKey)
        {
            Value = value;
            RoutingKey = routingKey;
        }
        
        
        public T Value { get; }
        
        public string RoutingKey { get; }
    }
}