using ARN.Pedidos.Damain.Common;
using System.ComponentModel.DataAnnotations;

namespace ARN.Pedidos.Damain.PedidoEntities
{
    public class PedidoDetalles : BaseAuditoria
    {
        [Key]
        public long PedidoDetalleId { get; set; }
        public long PedidoId { get; set; }
        public int EstadoCourierId { get; set; }
    }
}