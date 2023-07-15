using System;

#nullable disable

namespace basecs.Models
{
    public partial class GruposUsuarios
    {
        public Guid GrupoUsuarioId { get; set; }

        public Guid GrupoId { get; set; }

        public Guid UsuarioId { get; set; }

        public virtual Grupo Grupo { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
