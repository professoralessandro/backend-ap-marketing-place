using basecs.Enuns;
using System;

namespace basecs.Dtos.Usuarios
{
    public class InsertUserDto
    {
        public string Usuario { get; set; }
        public string NmrDocumento { get; set; }
        public TipoDocumentoEnum TipoDocumento { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string Email { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public DateTime DataUltimoLogin { get; set; }
    }
}
