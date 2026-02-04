namespace ARN.Pedido.Api.Errors
{
    public class CodeErrorException : CodeErrorResponse
    {
        public string? Detail { get; set; }

        public CodeErrorException(bool succes, int statusCode, string? message = null, string? detail = null) 
            : base(succes, statusCode, message)
        {
            Detail = detail;
        }
    }
}
