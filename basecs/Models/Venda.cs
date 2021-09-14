using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class Venda
    {
        public int VendaId { get; set; }
        public int UsuarioId { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
