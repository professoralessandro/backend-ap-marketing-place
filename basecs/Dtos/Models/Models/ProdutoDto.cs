﻿using basecs.Enuns;
using System;

#nullable disable

namespace basecs.Models
{
    public partial class ProdutoDto
    {
        public Guid ProdutoId { get; set; }

        public TipoProdutoEnum TipoProduto { get; set; }

        public string Descricao { get; set; }

        public string CodigoBarras { get; set; }

        public string Marca { get; set; }

        public int Quantidade { get; set; }

        public bool IsIlimitado { get; set; }

        public int? QuantidadeCritica { get; set; }

        public decimal PrecoCusto { get; set; }

        public decimal PrecoVenda { get; set; }

        public decimal MargemLucro { get; set; }

        public bool Bloqueado { get; set; }

        public Guid UsuarioInclusaoId { get; set; }

        public Guid? UsuarioUltimaAlteracaoId { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataUltimaAlteracao { get; set; }

        public bool Ativo { get; set; }

        public int? Peso { get; set; }
    }
}
