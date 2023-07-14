using System;

#nullable disable

namespace basecs.Models
{
    public partial class ConfiguracoesParametro
    {
        public Guid ConfiguracaoParametroId { get; set; }

        public Guid ParametroId { get; set; }

        public Guid ConfiguracaoId { get; set; }

        public virtual Configuracao Configuracao { get; set; }

        public virtual Parametro Parametro { get; set; }
    }
}
