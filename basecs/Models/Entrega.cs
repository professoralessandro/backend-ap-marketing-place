using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class Entrega
    {
        public Entrega()
        {
            Compras = new HashSet<Compra>();
        }

        public int EntregaId { get; set; }
        public int ResponsavelEntregaId { get; set; }
        public int TipoEntregaId { get; set; }
        public DateTime DataPrevistaEntrega { get; set; }
        public DateTime? DataEfetivaEnrega { get; set; }
        public string NmrDocumento { get; set; }
        public int TipoDocumentoId { get; set; }
        public string NomeRecebedor { get; set; }
        public bool IsEntregueTitular { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual Usuario ResponsavelEntrega { get; set; }
        public virtual TiposEntrega TipoEntrega { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
