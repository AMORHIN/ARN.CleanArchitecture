namespace ARN.Pedidos.Application.DTOS.PedidosDTO.PedidoComandDTO
{
    public class CreatePedidoDTO : BaseDTO
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
    }
}