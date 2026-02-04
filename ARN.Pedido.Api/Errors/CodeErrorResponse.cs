namespace ARN.Pedido.Api.Errors
{
    public class CodeErrorResponse
    {
        public bool Succes { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public CodeErrorResponse(bool succes, int statusCode, string? message = null)
        {
            Succes = succes;
            StatusCode = statusCode;
            Message = message ?? GetDefaultMesageCode(statusCode);
        }

        private string GetDefaultMesageCode(int statuCode)
        {
            return StatusCode switch
            {
                400 => "Request enviado tiene errores. ",
                401 => "No tienes autorizacion para el recurso",
                200 => "OK",
                500 => "Error de servidor",
                _ => string.Empty
            };
        }
    }
}
