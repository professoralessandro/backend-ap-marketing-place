using System;

#nullable disable

namespace basecs.Models
{
    public partial class AvaliacaoDto
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
    }
}
