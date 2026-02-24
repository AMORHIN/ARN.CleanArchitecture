using ARN.Pedidos.Application.Interfaces.DataBase;
using ARN.Pedidos.Damain.PedidoEntities;
using ARN.Pedidos.Domain.PedidoEntities;
using Microsoft.EntityFrameworkCore;

namespace ARN.Pedidos.Infrastructure.Persistence.DataBase
{
    internal class DataBasePedioServices : DbContext, IDataBasePedioServices
    {
        public DataBasePedioServices(DbContextOptions<DataBasePedioServices> options) : base(options)
        { }

        public DbSet<Pediddos> Pediddos { get; set; }
        public DbSet<PedidoDetalles> PedidoDetalles { get; set; }
        public DbSet<User> User { get; set; }

    }
}
