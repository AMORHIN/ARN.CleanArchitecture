using ARN.Pedidos.Damain.PedidoEntities;
using Microsoft.EntityFrameworkCore;

namespace ARN.Pedidos.Application.Interfaces.DataBase
{
    public interface IDataBasePedioServices
    {
        DbSet<Pediddos> Pedidos { get; set; }
        DbSet<PedidoDetalles> PedidoDetalles { get; set; }
    }
}
