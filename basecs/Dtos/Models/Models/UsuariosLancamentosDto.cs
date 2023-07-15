using System;

#nullable disable

namespace basecs.Models
{
    public partial class UsuariosLancamentosDto
    {
        public Guid UsuarioLancamentoId { get; set; }
        public Guid LancamentoId { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
