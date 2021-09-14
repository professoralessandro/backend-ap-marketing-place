using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class UsuariosDadosBancario
    {
        public int UsuarioDadoBancarioId { get; set; }
        public int UsuarioId { get; set; }
        public int DadoBancarioId { get; set; }

        public virtual DadosBancario DadoBancario { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
