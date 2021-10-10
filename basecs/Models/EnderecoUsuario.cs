using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class EnderecoUsuario
    {
        public int EnderecoUsuarioId { get; set; }
        public int EnderecoId { get; set; }
        public int UsuarioId { get; set; }

        public virtual Endereco Endereco { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
