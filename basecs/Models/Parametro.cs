using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class Parametro
    {
        public Parametro()
        {
            ConfiguracoesParametros = new HashSet<ConfiguracaoParametro>();
        }

        public int ParametroId { get; set; }
        public int TipoParametroId { get; set; }
        public int TipoDadoId { get; set; }
        public string Descricao { get; set; }
        public string Valor { get; set; }
        public bool Publico { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual TipoDado TipoDado { get; set; }
        public virtual TipoParametro TipoParametro { get; set; }
        public virtual ICollection<ConfiguracaoParametro> ConfiguracoesParametros { get; set; }
    }
}
