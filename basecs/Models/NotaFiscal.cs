
using System;

#nullable disable

namespace basecs.Models
{
    public partial class NotaFiscal
    {
        public int NotaFiscalId { get; set; }
        public int TipoNotaFiscalId { get; set; }
        public string ChaveAcesso { get; set; }
        public int UsuarioId { get; set; }
        public int DestinatarioId { get; set; }
        public string DadosAdicionais { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual Usuario Destinatario { get; set; }
        public virtual TipoNotaFiscal TipoNotaFiscal { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
