using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class Produto
    {
        public Produto()
        {
            Avaliacos = new HashSet<Avaliacao>();
            Compras = new HashSet<Compra>();
        }

        public int ProdutoId { get; set; }
        public int TipoProdutoId { get; set; }
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
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual TipoProduto TipoProduto { get; set; }
        public virtual ICollection<Avaliacao> Avaliacos { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
