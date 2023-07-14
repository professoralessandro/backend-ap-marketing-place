using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class Avaliacao
    {
        public Guid AvaliacaoId { get; set; }

        public Guid ProdutoId { get; set; }

        public Guid VendedorId { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public Guid UsuarioInclusaoId { get; set; }

        public Guid? UsuarioUltimaAlteracaoId { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataUltimaAlteracao { get; set; }

        public bool Ativo { get; set; }

        public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

        public virtual Produto Produto { get; set; }

        public virtual Usuario Vendedor { get; set; }
    }
}
