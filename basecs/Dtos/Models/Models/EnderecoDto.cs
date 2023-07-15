using basecs.Enuns;
using System;

#nullable disable

namespace basecs.Models
{
    public partial class EnderecoDto
    {
        public Guid EnderecoId { get; set; }

        public TipoEnderecoEnum TipoEndereco { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Cep { get; set; }

        public string PontoReferencia { get; set; }

        public Guid UsuarioInclusaoId { get; set; }

        public Guid? UsuarioUltimaAlteracaoId { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataUltimaAlteracao { get; set; }

        public bool IsPrincipal { get; set; }

        public bool Ativo { get; set; }
    }
}
