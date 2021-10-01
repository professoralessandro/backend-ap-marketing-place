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
        public decimal PrecoVenda { get; set; }
        public bool Bloqueado { get; set; }
        public DateTime Periodo { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual TipoGarantia TipoGarantia { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
