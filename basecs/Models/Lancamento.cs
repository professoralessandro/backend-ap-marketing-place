using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class Lancamento
    {
        public Lancamento()
        {
            Compras = new HashSet<Compra>();
            Pagamentos = new HashSet<Pagamento>();
            UsuariosLancamentos = new HashSet<UsuariosLancamento>();
        }

        public int LancamentoId { get; set; }
        public int TipoLancamentoId { get; set; }
        public int SituacaoId { get; set; }
        public string Referencia { get; set; }
        public decimal? ValorLancamento { get; set; }
        public DateTime? DataBaixa { get; set; }
        public string Observacao { get; set; }
        public int? UsuarioIdBaixa { get; set; }
        public int? LancamentoIdPai { get; set; }
        public int? QtdeParcelas { get; set; }
        public int? NmrParcela { get; set; }
        public decimal? ValorParcela { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual Situaco Situacao { get; set; }
        public virtual TipoLancamento TiposLancamentos { get; set; }
        public virtual Usuario UsuarioInclusao { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
        public virtual ICollection<Pagamento> Pagamentos { get; set; }
        public virtual ICollection<UsuariosLancamento> UsuariosLancamentos { get; set; }
    }
}
