using System;

#nullable disable

namespace basecs.Models
{
    public partial class UsuariosDadosBancariosDto
    {
        public Guid UsuarioDadoBancarioId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid DadoBancarioId { get; set; }
    }
}
