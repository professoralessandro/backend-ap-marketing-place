
#nullable disable

namespace basecs.Models
{
    public partial class ConfiguracaoParametro
    {
        public int ConfiguracaoParametroId { get; set; }
        public int ParametroId { get; set; }
        public int ConfiguracaoId { get; set; }

        public virtual Configuracao Configuracao { get; set; }
        public virtual Parametro Parametro { get; set; }
    }
}
