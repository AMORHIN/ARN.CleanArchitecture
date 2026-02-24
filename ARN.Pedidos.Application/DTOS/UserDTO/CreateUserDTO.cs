namespace ARN.Pedidos.Application.DTOS.UserDTO
{
    public class CreateUserDTO
    {
        public int RolId { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
    }
}
