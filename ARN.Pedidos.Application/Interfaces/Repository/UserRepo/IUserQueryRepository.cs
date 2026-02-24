using ARN.Pedidos.Application.DTOS.UserDTO;

namespace ARN.Pedidos.Application.Interfaces.Repository.UserRepo
{
    public interface IUserQueryRepository
    {
        Task<GetByIdUserDTO> GetByIdUserDTO(int id);
        Task<List<GetUserDTO>> GetUserDTO(string? Usuario);
        Task<GetUserDTO> getUserPassword(string Usuario);
    }
}