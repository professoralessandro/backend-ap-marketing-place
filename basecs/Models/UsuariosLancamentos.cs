using System;

#nullable disable

namespace basecs.Models
{
    public partial class UsuariosLancamentos
    {
        public Guid UsuarioLancamentoId { get; set; }
        public Guid LancamentoId { get; set; }
        public Guid UsuarioId { get; set; }

        public virtual Lancamento Lancamento { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
