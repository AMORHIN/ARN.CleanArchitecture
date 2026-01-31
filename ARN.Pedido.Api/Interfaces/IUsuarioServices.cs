using ARN.Pedido.Api.Model;

namespace ARN.Pedido.Api.Interfaces
{
    public interface IUsuarioServices
    {
        Task<int> CrearUsuario(UserModel userModel);
        Task<int> ActualizarUsuario(UserModel userModel);
        Task<List<UserModel>> ListaUsuarios(string? nombre);
        Task<UserModel> ListaIdUsuarios(int UsuarioId);
    }
}
