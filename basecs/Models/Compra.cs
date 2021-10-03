using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class Compra
    {
        public int CompraId { get; set; }
        public string CodigoCompra { get; set; }
        public string CodigoPagamento { get; set; }
        public int ProdutoId { get; set; }
        public int CompradorId { get; set; }
        public int FormaPagamentoId { get; set; }
        public int StatusCompraId { get; set; }
        public int EntregaId { get; set; }
        public int LancamentoPaiId { get; set; }
        public int EnderecoId { get; set; }
        public int GarantiaId { get; set; }
        public int TelefoneId { get; set; }
        public int VendedorId { get; set; }
        public int AvaliacaoId { get; set; }
        public bool IsPago { get; set; }
        public bool IsEntregue { get; set; }
        public bool IsAvaliado { get; set; }
        public bool Ativo { get; set; }

        public virtual Avaliacao Avaliacao { get; set; }
        public virtual Usuario Comprador { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual Entrega Entrega { get; set; }
        public virtual FormasPagamento FormaPagamento { get; set; }
        public virtual Garantia Garantia { get; set; }
        public virtual Lancamento LancamentoPai { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual Situaco StatusCompra { get; set; }
    }
}
