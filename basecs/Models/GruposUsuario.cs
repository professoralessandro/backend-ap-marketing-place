using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class GruposUsuario
    {
        public int GrupoUsuarioId { get; set; }
        public int GrupoId { get; set; }
        public int UsuarioId { get; set; }

        public virtual Grupo Grupo { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
