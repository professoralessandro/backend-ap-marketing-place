using basecs.Enuns;
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
            UsuariosLancamentos = new HashSet<UsuariosLancamento>();
        }

        public int LancamentoId { get; set; }
        public TipoLancamentoEnum TipoLancamento { get; set; }
        public int UsuarioId { get; set; }
        public int SituacaoId { get; set; }
        public string Referencia { get; set; }
        public decimal? ValorLancamento { get; set; }
        public DateTime? DataMovimento { get; set; }
        public DateTime? DataBaixa { get; set; }
        public string Observacao { get; set; }
        public int? UsuarioIdBaixa { get; set; }
        public int? LancamentoIdPai { get; set; }
        public string NroAutorizacao { get; set; }
        public string NroAutenticacao { get; set; }
        public string NroComprovante { get; set; }
        public string NroPedido { get; set; }
        public int? FormaPagamentoId { get; set; }
        public int? QtdeParcelas { get; set; }
        public decimal? ValorParcela { get; set; }

        public virtual Situaco Situacao { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
        public virtual ICollection<UsuariosLancamento> UsuariosLancamentos { get; set; }
    }
}
