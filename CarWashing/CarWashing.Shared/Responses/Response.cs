namespace CarWashing.Shared.Responses
{
    public class Response
    {
        public bool WasSuccess { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }
    }
}