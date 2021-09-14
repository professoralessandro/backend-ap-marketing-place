using System;

#nullable disable

namespace basecs.Models
{
    public partial class Mensagen
    {
        public long MensagemId { get; set; }
        public int RemetenteId { get; set; }
        public string Mensagem { get; set; }
        public int TipoMensagemId { get; set; }
        public bool IsHtml { get; set; }
        public int DestinatarioId { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual Usuario Remetente { get; set; }
    }
}
