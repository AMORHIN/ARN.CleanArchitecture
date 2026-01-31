namespace ARN.Pedidos.Application.DTOS.PedidosDTO.PedidoComandDTO
{
    public class UpdatePedidoDTO : BaseDTO
    {
        public long PedidoId { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
    }
}