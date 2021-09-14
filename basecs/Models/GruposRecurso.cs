using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class GruposRecurso
    {
        public int GrupoRecursoId { get; set; }
        public int GrupoId { get; set; }
        public int RecursoId { get; set; }

        public virtual Grupo Grupo { get; set; }
        public virtual Recurso Recurso { get; set; }
    }
}
