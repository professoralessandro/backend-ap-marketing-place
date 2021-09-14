using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class Email
    {
        public int EmailId { get; set; }
        public int UsuarioEnvioId { get; set; }
        public int TipoEmailId { get; set; }
        public string NomeEmail { get; set; }
        public string Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        public bool Html { get; set; }
        public bool Enviado { get; set; }
        public int Tentativas { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual TiposEmail TipoEmail { get; set; }
        public virtual Usuario UsuarioEnvio { get; set; }
    }
}
