using basecs.Enuns;
using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class Usuario
    {
        public Guid UsuarioId { get; set; }

        public string Usuario1 { get; set; }

        public string NmrDocumento { get; set; }

        public TipoDocumentoEnum TipoDocumento { get; set; }

        public string Senha { get; set; }

        public string Nome { get; set; }

        public DateTime? DataNascimento { get; set; }

        public string Sexo { get; set; }

        public string EstadoCivil { get; set; }

        public string Email { get; set; }

        public bool TrocaSenha { get; set; }

        public bool Bloqueado { get; set; }

        public Guid UsuarioInclusaoId { get; set; }

        public Guid? UsuarioUltimaAlteracaoId { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataUltimaAlteracao { get; set; }

        public DateTime? DataUltimaTrocaSenha { get; set; }

        public DateTime? DataUltimoLogin { get; set; }

        public string NmrTelefone { get; set; }

        public bool Ativo { get; set; }

        public virtual ICollection<Avaliacao> Avaliacos { get; set; } = new List<Avaliacao>();

        public virtual ICollection<CartoesBancario> CartoesBancarios { get; set; } = new List<CartoesBancario>();

        public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

        public virtual ICollection<DadosBancario> DadosBancarios { get; set; } = new List<DadosBancario>();

        public virtual ICollection<Email> Emails { get; set; } = new List<Email>();

        public virtual ICollection<Entrega> Entregas { get; set; } = new List<Entrega>();

        public virtual ICollection<GruposUsuario> GruposUsuarios { get; set; } = new List<GruposUsuario>();

        public virtual ICollection<Lancamento> Lancamentos { get; set; } = new List<Lancamento>();

        public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

        public virtual ICollection<Mensagen> Mensagens { get; set; } = new List<Mensagen>();

        public virtual ICollection<UsuariosDadosBancario> UsuariosDadosBancarios { get; set; } = new List<UsuariosDadosBancario>();

        public virtual ICollection<UsuariosLancamento> UsuariosLancamentos { get; set; } = new List<UsuariosLancamento>();
    }
}
