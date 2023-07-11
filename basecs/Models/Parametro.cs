using basecs.Enuns;
using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class Parametro
    {
        public Parametro()
        {
            ConfiguracoesParametros = new HashSet<ConfiguracoesParametro>();
        }

        public int ParametroId { get; set; }
        public TipoParametroEnum TipoParametro { get; set; }
        public TipoDadoEnum TipoDado { get; set; }
        public string Descricao { get; set; }
        public string Valor { get; set; }
        public bool Publico { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<ConfiguracoesParametro> ConfiguracoesParametros { get; set; }
    }
}
