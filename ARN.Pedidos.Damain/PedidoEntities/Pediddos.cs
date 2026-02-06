using ARN.Pedidos.Damain.Common;
using System.ComponentModel.DataAnnotations;

namespace ARN.Pedidos.Damain.PedidoEntities
{
    public class Pediddos : BaseAuditoria
    {
        [Key]
        public long PedidoId { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }

    }
}