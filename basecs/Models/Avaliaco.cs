using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class Avaliaco
    {
        public Avaliaco()
        {
            Compras = new HashSet<Compra>();
        }

        public int AvaliacaoId { get; set; }
        public int ProdutoId { get; set; }
        public int VendedorId { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual Produto Produto { get; set; }
        public virtual Usuario Vendedor { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
