namespace MasterLinkLite.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Proposito { get; set; }
        public string Url { get; set; }
        public int UsuarioId { get; set; }
    }
}
