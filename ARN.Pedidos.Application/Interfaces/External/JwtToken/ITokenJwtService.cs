using ARN.Pedidos.Application.DTOS.JwtDTO;

namespace ARN.Pedidos.Application.Interfaces.External.JwtToken
{
    public interface ITokenJwtService
    {
        string GeradorTOken(UserPasswordDTO user);
        string Hash(string password);
        (bool Verified, bool NeedsUpgrade) Check(string hash, string password);
    }
}