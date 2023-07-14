using basecs.Enuns;
using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class Entrega
    {
        public Guid EntregaId { get; set; }

        public Guid ResponsavelEntregaId { get; set; }

        public TipoEntregaEnum TipoEntrega { get; set; }

        public DateTime DataPrevistaEntrega { get; set; }

        public DateTime? DataEfetivaEnrega { get; set; }

        public string NmrDocumento { get; set; }

        public int TipoDocumento { get; set; }

        public string NomeRecebedor { get; set; }

        public bool IsEntregueTitular { get; set; }

        public Guid UsuarioInclusaoId { get; set; }

        public Guid? UsuarioUltimaAlteracaoId { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataUltimaAlteracao { get; set; }

        public bool Ativo { get; set; }

        public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

        public virtual Usuario ResponsavelEntrega { get; set; }
    }
}
