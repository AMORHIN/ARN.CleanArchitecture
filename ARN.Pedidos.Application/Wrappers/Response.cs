namespace ARN.Pedidos.Application.Wrappers
{
    public class Response<T>
    {
        public Response(int v) { }

        public Response(T data, int status, string message = null)
        {
            Success = true;
            Status = status;
            Message = message;
            Data = data;
        }

        public int Status { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}
