
using System;

#nullable disable

namespace basecs.Models
{
    public partial class Pagamento
    {
        public int PagamentoId { get; set; }
        public int LancamentoId { get; set; }
        public string CodigoPagamento { get; set; }
        public string ChagoExterno { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual Lancamento Lancamento { get; set; }
    }
}
