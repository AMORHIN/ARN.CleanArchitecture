using ARN.Pedidos.Damain.PedidoEntities;
using ARN.Pedidos.Domain.PedidoEntities;
using Microsoft.EntityFrameworkCore;

namespace ARN.Pedidos.Application.Interfaces.DataBase
{
    public interface IDataBasePedioServices
    {
        DbSet<Pediddos> Pediddos { get; set; }
        DbSet<PedidoDetalles> PedidoDetalles { get; set; }
        DbSet<User> User { get; set; }
    }
}
