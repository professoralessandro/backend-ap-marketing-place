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
            Entregas = new HashSet<Entrega>();
            GruposUsuarios = new HashSet<GruposUsuario>();
            Lancamentos = new HashSet<Lancamento>();
            Logs = new HashSet<Log>();
            Mensagens = new HashSet<Mensagen>();
            UsuariosDadosBancarios = new HashSet<UsuariosDadosBancario>();
            UsuariosLancamentos = new HashSet<UsuariosLancamento>();
            Venda = new HashSet<Venda>();
        }

        public int UsuarioId { get; set; }
        public string Usuario1 { get; set; }
        public string NmrDocumento { get; set; }
        public int TipoDocumentoId { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string Email { get; set; }
        public bool TrocaSenha { get; set; }
        public bool Bloqueado { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public DateTime DataUltimaTrocaSenha { get; set; }
        public DateTime? DataUltimoLogin { get; set; }
        public bool Ativo { get; set; }

        public virtual TipoDocumento TipoDocumento { get; set; }
        public virtual ICollection<Avaliacao> Avaliacos { get; set; }
        public virtual ICollection<CartoesBancario> CartoesBancarios { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
        public virtual ICollection<DadosBancario> DadosBancarios { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Entrega> Entregas { get; set; }
        public virtual ICollection<GruposUsuario> GruposUsuarios { get; set; }
        public virtual ICollection<Lancamento> Lancamentos { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
        public virtual ICollection<Mensagen> Mensagens { get; set; }
        public virtual ICollection<UsuariosDadosBancario> UsuariosDadosBancarios { get; set; }
        public virtual ICollection<UsuariosLancamento> UsuariosLancamentos { get; set; }
        public virtual ICollection<Venda> Venda { get; set; }
    }
}
