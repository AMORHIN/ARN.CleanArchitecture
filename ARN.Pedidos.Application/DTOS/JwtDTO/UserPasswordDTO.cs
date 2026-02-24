namespace ARN.Pedidos.Application.DTOS.JwtDTO
{
    public class UserPasswordDTO
    {
        public int UsuarioId { get; set; }
        public string Usuario { get; set; }
        public string Rol { get; set; }
        public string Correo { get; set; }
        //public string Password { get; set; }
    }
}