using basecs.Enuns;
using System;

namespace basecs.Dtos.Compras
{
    public class EditCompraDto
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string NmrDocumento { get; set; }
        public TipoDocumentoEnum TipoDocumento { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string Email { get; set; }
        public bool TrocaSenha { get; set; }
        public bool Bloqueado { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public DateTime DataUltimaTrocaSenha { get; set; }
        public DateTime? DataUltimoLogin { get; set; }
        public bool Ativo { get; set; }
    }
}
