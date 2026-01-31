using ARN.Pedido.Api.Model;

namespace ARN.Pedido.Api.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<int> CrearUsuario(UserModel userModel);
        Task<List<UserModel>> ListaUsuarios(string? nombre);
        Task<UserModel> ListaIdUsuarios(int UsuarioId);
    }
}
