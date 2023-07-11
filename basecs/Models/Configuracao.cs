using basecs.Enuns;
using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class Configuracao
    {
        public Configuracao()
        {
            ConfiguracoesParametros = new HashSet<ConfiguracoesParametro>();
        }

        public int ConfiguracaoId { get; set; }
        public TipoConfiguracaoEnum TipoConfiguracao { get; set; }
        public string Descricao { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<ConfiguracoesParametro> ConfiguracoesParametros { get; set; }
    }
}
