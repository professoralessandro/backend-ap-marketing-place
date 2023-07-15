using System;

#nullable disable

namespace basecs.Models
{
    public partial class Imagem
    {
        public Guid ImagemId { get; set; }

        public string Path { get; set; }

        public string Descricao { get; set; }

        public bool ImagemPrincipal { get; set; }

        public bool Publico { get; set; }

        public Guid UsuarioInclusaoId { get; set; }

        public Guid? UsuarioUltimaAlteracaoId { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataUltimaAlteracao { get; set; }

        public bool Ativo { get; set; }
    }
}
