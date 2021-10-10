#nullable disable

namespace basecs.Models
{
    public partial class TelefoneUsuario
    {
        public int TelefoneUsuarioId { get; set; }
        public int TelefoneId { get; set; }
        public int UsuarioId { get; set; }

        public virtual Telefone Telefone { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
