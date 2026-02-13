namespace ARN.Pedidos.Application.UseCases.Pedidos.Queries.GetAllPedido
{
    public class GetAllPedidoModel
    {
        public long PedidoId { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? FechaCreacion { get; set; }
        public List<PedidoDetalleModel>? PedidoDetalle { get; set; }
    }


    public class PedidoDetalleModel
    {
        public long PedidoDetalleId { get; set; }
        public int EstadoId { get; set; }
        public int Nombreestado { get; set; }
    }
}