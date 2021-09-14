using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class Telefone
    {
        public int TelefoneId { get; set; }
        public int TipoTelefoneId { get; set; }
        public string Telefone1 { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual TipoTelefone TipoTelefone { get; set; }
    }
}
