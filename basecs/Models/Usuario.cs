using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Avaliacos = new HashSet<Avaliacao>();
            CartoesBancarios = new HashSet<CartoesBancario>();
            Compras = new HashSet<Compra>();
            DadosBancarios = new HashSet<DadosBancario>();
            Emails = new HashSet<Email>();
            EnderecosUsuarios = new HashSet<EnderecoUsuario>();
            Entregas = new HashSet<Entrega>();
            Lancamentos = new HashSet<Lancamento>();
            Logs = new HashSet<Log>();
            Mensagens = new HashSet<Mensagem>();
            NotasFiscaiDestinatarios = new HashSet<NotaFiscal>();
            NotasFiscaiUsuarios = new HashSet<NotaFiscal>();
            TelefonesUsuarios = new HashSet<TelefoneUsuario>();
        }

        public int UsuarioId { get; set; }
        public int GrupoUsaruiId { get; set; }
        public string Login { get; set; }
        public string NmrDocumento { get; set; }
        public int TipoDocumentoId { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string Email { get; set; }
        public bool Bloqueado { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public DateTime DataUltimaTrocaSenha { get; set; }
        public DateTime? DataUltimoLogin { get; set; }
        public bool Ativo { get; set; }

        public virtual Grupo GrupoUsarui { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
        public virtual ICollection<Avaliacao> Avaliacos { get; set; }
        public virtual ICollection<CartoesBancario> CartoesBancarios { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
        public virtual ICollection<DadosBancario> DadosBancarios { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<EnderecoUsuario> EnderecosUsuarios { get; set; }
        public virtual ICollection<Entrega> Entregas { get; set; }
        public virtual ICollection<Lancamento> Lancamentos { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
        public virtual ICollection<Mensagem> Mensagens { get; set; }
        public virtual ICollection<NotaFiscal> NotasFiscaiDestinatarios { get; set; }
        public virtual ICollection<NotaFiscal> NotasFiscaiUsuarios { get; set; }
        public virtual ICollection<TelefoneUsuario> TelefonesUsuarios { get; set; }
    }
}
