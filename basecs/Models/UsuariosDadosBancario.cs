using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class UsuariosDadosBancario
    {
        public Guid UsuarioDadoBancarioId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid DadoBancarioId { get; set; }

        public virtual DadosBancario DadoBancario { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
