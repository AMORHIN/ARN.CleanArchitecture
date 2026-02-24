using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARN.Pedidos.Domain.PedidoEntities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public int RolId { get; set; }
    }
}
