using System;

#nullable disable

namespace basecs.Models
{
    public partial class UsuariosDadosBancarios
    {
        public Guid UsuarioDadoBancarioId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid DadoBancarioId { get; set; }

        public virtual DadosBancario DadoBancario { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
