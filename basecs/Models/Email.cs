using basecs.Enuns;
using System;

#nullable disable

namespace basecs.Models
{
    public partial class Email
    {
        public Guid EmailId { get; set; }

        public Guid UsuarioEnvioId { get; set; }

        public TipoEmailEnum TipoEmail { get; set; }

        public string NomeEmail { get; set; }

        public string Destinatario { get; set; }

        public string Assunto { get; set; }

        public string Mensagem { get; set; }

        public bool Html { get; set; }

        public StatusEnvioEnum StatusEnvio { get; set; }

        public int Tentativas { get; set; }

        public Guid UsuarioInclusaoId { get; set; }

        public Guid? UsuarioUltimaAlteracaoId { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataUltimaAlteracao { get; set; }

        public bool Ativo { get; set; }

        public virtual Usuario UsuarioEnvio { get; set; }
    }
}
