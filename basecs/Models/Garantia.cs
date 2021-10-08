using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class Garantia
    {
        public Garantia()
        {
            Compras = new HashSet<Compra>();
        }

        public int GarantiaId { get; set; }
        public int TipoGarantiaId { get; set; }
        public string Descricao { get; set; }
        public string Detalhes { get; set; }
        public string Periodo { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Fim { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual TipoGarantia TipoGarantia { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
