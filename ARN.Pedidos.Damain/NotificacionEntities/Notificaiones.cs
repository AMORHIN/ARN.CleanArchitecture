using ARN.Pedidos.Damain.Common;

namespace ARN.Pedidos.Damain.NotificacionEntities
{
    public class Notificaiones : BaseAuditoria
    {
        public long NotificacionId { get; set; }
        public long PedidoDetalleId { get; set; }
        public long ClienteId { get; set; }
    }
}
