namespace ARN.Pedidos.Application.Wrappers
{
    public class ResultData
    {
        public long NewId { get; set; }
        public string? Message { get; set; }
        public List<string>? Error { get; set; }
    }
}