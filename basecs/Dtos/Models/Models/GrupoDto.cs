using System;

#nullable disable

namespace basecs.Models
{
    public partial class GrupoDto
    {
        public Guid GrupoId { get; set; }

        public string Grupo1 { get; set; }

        public Guid UsuarioInclusaoId { get; set; }

        public Guid? UsuarioUltimaAlteracaoId { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataUltimaAlteracao { get; set; }

        public bool Ativo { get; set; }
    }
}
