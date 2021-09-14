using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class FormasPagamento
    {
        public FormasPagamento()
        {
            Compras = new HashSet<Compra>();
        }

        public int FormaPagamentoId { get; set; }
        public string Descricao { get; set; }
        public bool PermiteParcelar { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
    }
}
