using basecs.Enuns;
using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class Garantia
    {
        public Guid GarantiaId { get; set; }

        public TipoGarantiaEnum TipoGarantia { get; set; }

        public string Descricao { get; set; }

        public string Detalhes { get; set; }

        public string Periodo { get; set; }

        public DateTime? Inicio { get; set; }

        public DateTime? Fim { get; set; }

        public Guid UsuarioInclusaoId { get; set; }

        public Guid? UsuarioUltimaAlteracaoId { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataUltimaAlteracao { get; set; }

        public bool Ativo { get; set; }

        public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
    }
}
