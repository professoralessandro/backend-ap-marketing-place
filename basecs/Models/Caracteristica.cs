using basecs.Enuns;
using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class Caracteristica
    {
        public int CaracteristicaId { get; set; }
        public TipoCaracteristicaEnum TipoCaracteristica { get; set; }
        public string Descricao { get; set; }
        public int? Ordem { get; set; }
        public bool Publico { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }
    }
}
