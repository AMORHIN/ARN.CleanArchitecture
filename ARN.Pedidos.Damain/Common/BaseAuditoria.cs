namespace ARN.Pedidos.Damain.Common
{
    public class BaseAuditoria
    {
        public bool Esatado { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateFecha { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateFecha { get; set; }
        public int DeleteUserId { get; set; }
        public DateTime DeleteFecha { get; set; }
    }
}