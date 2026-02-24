using ARN.Pedidos.Application.DTOS.UserDTO;
using ARN.Pedidos.Application.Interfaces.Repository.UserRepo;
using ARN.Pedidos.Infrastructure.Persistence.DataBase;
using Microsoft.EntityFrameworkCore;

namespace ARN.Pedidos.Infrastructure.Persistence.Repository.UserRepo
{
    internal class UserQueryRepository : IUserQueryRepository
    {
        protected DataBasePedioServices _context;

        public UserQueryRepository(DataBasePedioServices context) => _context = context;

        public async Task<GetByIdUserDTO> GetByIdUserDTO(int id)
        {
            var result = await (from t1 in _context.User
                                where t1.UserId == id
                                select new GetByIdUserDTO
                                {
                                    UsuarioId = t1.UserId,
                                    RolId = t1.RolId,
                                    Usuario = t1.UserName,
                                }).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<GetUserDTO>> GetUserDTO(string? Usuario)
        {
            var result = await (from t1 in _context.User
                                where string.IsNullOrEmpty(Usuario) || t1.UserName == Usuario
                                select new GetUserDTO
                                {
                                    UsuarioId = t1.UserId,
                                    RolId = t1.RolId,
                                    Usuario = t1.UserName,
                                }).ToListAsync();
            return result;
        }

        public async Task<GetUserDTO> getUserPassword(string Usuario)
        {
            var result = await (from t1 in _context.User
                                where string.IsNullOrEmpty(Usuario) || t1.UserName == Usuario
                                select new GetUserDTO
                                {
                                    UsuarioId = t1.UserId,
                                    RolId = t1.RolId,
                                    Usuario = t1.UserName,
                                    Password = t1.Password,
                                }).FirstOrDefaultAsync();
            return result;
        }
    }
}
