using ARN.Pedidos.Damain.Common;

namespace ARN.Pedidos.Damain.DeliveryEntities
{
    public class Evidencias : BaseAuditoria
    {
        public long EvidenciaId { get; set; }
        public long PedidoDetalleId { get; set; }
        public string Url { get; set; }
        public string Extension { get; set; }
    }
}