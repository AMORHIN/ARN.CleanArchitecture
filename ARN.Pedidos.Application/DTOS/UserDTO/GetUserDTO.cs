namespace ARN.Pedidos.Application.DTOS.UserDTO
{
    public class GetUserDTO
    {
        public int UsuarioId { get; set; }
        public int RolId { get; set; }
        public string Rol { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
    }
}
