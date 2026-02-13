namespace ARN.Pedidos.Application.DTOS.PedidosDTO.PedidoQuerieDTO
{
    public class GetAllPedidoDTO : BaseDTO
    {
        public long PedidoId { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
