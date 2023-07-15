using System;

#nullable disable

namespace basecs.Models
{
    public partial class GruposRecursoDto
    {
        public Guid GrupoRecursoId { get; set; }

        public Guid GrupoId { get; set; }

        public Guid RecursoId { get; set; }

        public virtual Grupo Grupo { get; set; }

        public virtual Recurso Recurso { get; set; }
    }
}
