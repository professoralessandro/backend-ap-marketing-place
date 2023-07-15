using basecs.Enuns;
using System;

#nullable disable

namespace basecs.Models
{
    public partial class TelefoneDto
    {
        public Guid TelefoneId { get; set; }
        public TipoTelefoneEnum TipoTelefone { get; set; }
        public string Numero { get; set; }
        public Guid UsuarioInclusaoId { get; set; }
        public Guid UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }
    }
}
