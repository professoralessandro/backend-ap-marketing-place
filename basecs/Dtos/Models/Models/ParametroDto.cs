using basecs.Enuns;
using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class ParametroDto
    {
        public Guid ParametroId { get; set; }

        public TipoParametroEnum TipoParametro { get; set; }

        public TipoDadoEnum TipoDado { get; set; }

        public string Descricao { get; set; }

        public string Valor { get; set; }

        public bool Publico { get; set; }

        public bool Ativo { get; set; }
    }
}
