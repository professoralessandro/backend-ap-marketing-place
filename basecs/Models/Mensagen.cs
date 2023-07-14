using basecs.Enuns;
using System;

#nullable disable

namespace basecs.Models
{
    public partial class Mensagen
    {
        public Guid MensagemId { get; set; }

        public Guid RemetenteId { get; set; }

        public string Mensagem { get; set; }

        public TipoMenssagemEnum TipoMensagem { get; set; }

        public bool IsHtml { get; set; }

        public int DestinatarioId { get; set; }

        public Guid UsuarioInclusaoId { get; set; }

        public Guid? UsuarioUltimaAlteracaoId { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataUltimaAlteracao { get; set; }

        public bool Ativo { get; set; }

        public virtual Usuario Remetente { get; set; }
    }
}
