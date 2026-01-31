using ARN.Pedidos.Damain.Common;

namespace ARN.Pedidos.Damain.PedidoEntities
{
    public class PedidoDetalles : BaseAuditoria
    {
        public long PedidoDetalleId { get; set; }
        public long PedidoId { get; set; }
        public int EstadoCourierId { get; set; }
    }
}