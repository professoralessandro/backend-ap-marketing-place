﻿using basecs.Enuns;
using System;

#nullable disable

namespace basecs.Models
{
    public partial class CompraDto
    {
        public Guid CompraId { get; set; }

        public string CodigoCompra { get; set; }

        public string CodigoPagamento { get; set; }

        public Guid ProdutoId { get; set; }

        public Guid CompradorId { get; set; }

        public FormaPagamentoEnum FormaPagamento { get; set; }

        public StatusCompraEnum StatusCompra { get; set; }

        public Guid EntregaId { get; set; }

        public Guid LancamentoPaiId { get; set; }

        public Guid EnderecoId { get; set; }

        public Guid GarantiaId { get; set; }

        public Guid VendedorId { get; set; }

        public Guid AvaliacaoId { get; set; }

        public bool IsPago { get; set; }

        public bool IsEntregue { get; set; }

        public bool IsAvaliado { get; set; }

        public bool Ativo { get; set; }
    }
}