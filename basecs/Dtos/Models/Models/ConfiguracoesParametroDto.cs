using System;

#nullable disable

namespace basecs.Models
{
    public partial class ConfiguracoesParametroDto
    {
        public Guid ConfiguracaoParametroId { get; set; }

        public Guid ParametroId { get; set; }

        public Guid ConfiguracaoId { get; set; }
    }
}
