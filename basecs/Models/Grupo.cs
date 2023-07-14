using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class Grupo
    {
        public Guid GrupoId { get; set; }

        public string Grupo1 { get; set; }

        public Guid UsuarioInclusaoId { get; set; }

        public Guid? UsuarioUltimaAlteracaoId { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataUltimaAlteracao { get; set; }

        public bool Ativo { get; set; }

        public virtual ICollection<GruposRecurso> GruposRecursos { get; set; } = new List<GruposRecurso>();

        public virtual ICollection<GruposUsuario> GruposUsuarios { get; set; } = new List<GruposUsuario>();
    }
}
