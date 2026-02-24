using ARN.Pedidos.Application.DTOS.UserDTO;

namespace ARN.Pedidos.Application.Interfaces.Repository.UserRepo
{
    public interface IUserCommandRepository
    {
        Task<int> CreateUser(CreateUserDTO createUser);
    }
}