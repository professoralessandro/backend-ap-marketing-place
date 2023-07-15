using basecs.Enuns;
using System;

#nullable disable

namespace basecs.Models
{
    public partial class CaracteristicaDto
    {
        public Guid CaracteristicaId { get; set; }

        public TipoCaracteristicaEnum TipoCaracteristica { get; set; }

        public string Descricao { get; set; }

        public int? Ordem { get; set; }

        public bool Publico { get; set; }

        public Guid UsuarioInclusaoId { get; set; }

        public Guid? UsuarioUltimaAlteracaoId { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataUltimaAlteracao { get; set; }

        public bool Ativo { get; set; }
    }
}
