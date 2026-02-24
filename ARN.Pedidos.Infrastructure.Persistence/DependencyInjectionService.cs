using ARN.Pedidos.Application.Interfaces.Repository.Pedidos;
using ARN.Pedidos.Application.Interfaces.Repository.UserRepo;
using ARN.Pedidos.Infrastructure.Persistence.DataBase;
using ARN.Pedidos.Infrastructure.Persistence.Repository.Pedidos;
using ARN.Pedidos.Infrastructure.Persistence.Repository.UserRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ARN.Pedidos.Infrastructure.Persistence
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionDataBasePedidos = configuration["ConnectionStringPedidos"];
            services.AddDbContext<DataBasePedioServices>(options => options.UseSqlServer(connectionDataBasePedidos));       

            services.AddScoped<IPedidoCommandRepository, PedidoCommandRepository>();
            services.AddScoped<IPedidoQuerieRepository, PedidoQuerieRepository>();

            services.AddScoped<IUserCommandRepository, UserCommandRepository>();
            services.AddScoped<IUserQueryRepository, UserQueryRepository>();


            return services;
        }
    }
}
