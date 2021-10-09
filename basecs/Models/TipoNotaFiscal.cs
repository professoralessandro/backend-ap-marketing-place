using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class TipoNotaFiscal
    {
        public TipoNotaFiscal()
        {
            NotasFiscais = new HashSet<NotaFiscal>();
        }

        public int TipoNotaFiscalId { get; set; }
        public string Descricao { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<NotaFiscal> NotasFiscais { get; set; }
    }
}
