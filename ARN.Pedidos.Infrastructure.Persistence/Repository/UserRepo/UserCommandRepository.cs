using ARN.Pedidos.Application.DTOS.UserDTO;
using ARN.Pedidos.Application.Interfaces.Repository.UserRepo;
using ARN.Pedidos.Domain.PedidoEntities;
using ARN.Pedidos.Infrastructure.Persistence.DataBase;

namespace ARN.Pedidos.Infrastructure.Persistence.Repository.UserRepo
{
    internal class UserCommandRepository : IUserCommandRepository
    {
        protected DataBasePedioServices _context;

        public UserCommandRepository(DataBasePedioServices context) => _context = context;

        public async Task<int> CreateUser(CreateUserDTO createUser)
        {
            await using var myTransaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var uu = new User
                {
                    UserName = createUser.Usuario,
                    LastName = createUser.Usuario,
                    FirsName = createUser.Usuario,
                    RolId = createUser.RolId,
                    Password = createUser.Password,
                };

                await _context.User.AddAsync(uu);
                await _context.SaveChangesAsync();
                await myTransaction.CommitAsync();

                return uu.UserId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
