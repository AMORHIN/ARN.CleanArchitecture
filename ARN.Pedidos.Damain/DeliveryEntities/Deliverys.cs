using ARN.Pedidos.Damain.Common;

namespace ARN.Pedidos.Damain.DeliveryEntities
{
    public class Deliverys : BaseAuditoria
    {
        public long DeliveryId { get; set; }
        public long PedidoId { get; set; }
        public long CourierId { get; set; }
        public long MovilidadId { get; set; }
    }
}
