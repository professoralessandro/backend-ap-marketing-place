#nullable disable

namespace basecs.Models
{
    public partial class BloqueioUsuario
    {
        public int BloqueioUsuarioId { get; set; }
        public int BloqueioId { get; set; }
        public int UsuarioId { get; set; }

        public virtual Bloqueio Bloqueio { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
