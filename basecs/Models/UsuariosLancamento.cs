using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class UsuariosLancamento
    {
        public int UsuarioLancamentoId { get; set; }
        public int LancamentoId { get; set; }
        public int UsuarioId { get; set; }

        public virtual Lancamento Lancamento { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
