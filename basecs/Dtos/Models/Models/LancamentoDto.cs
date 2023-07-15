using basecs.Enuns;
using System;

#nullable disable

namespace basecs.Models
{
    public partial class LancamentoDto
    {
        public Guid LancamentoId { get; set; }

        public TipoLancamentoEnum TipoLancamento { get; set; }

        public Guid UsuarioId { get; set; }

        public int Situacao { get; set; }

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
    }
}
