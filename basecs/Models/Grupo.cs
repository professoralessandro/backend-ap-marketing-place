using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class Grupo
    {
        public Grupo()
        {
            GruposRecursos = new HashSet<GruposRecurso>();
            GruposUsuarios = new HashSet<GruposUsuario>();
        }

        public int GrupoId { get; set; }
        public string Grupo1 { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<GruposRecurso> GruposRecursos { get; set; }
        public virtual ICollection<GruposUsuario> GruposUsuarios { get; set; }
    }
}
