using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class FormasPagamento
    {
        public Guid FormaPagamentoId { get; set; }

        public string Descricao { get; set; }

        public bool PermiteParcelar { get; set; }

        public Guid UsuarioInclusaoId { get; set; }

        public Guid? UsuarioUltimaAlteracaoId { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataUltimaAlteracao { get; set; }

        public bool Ativo { get; set; }
    }
}
