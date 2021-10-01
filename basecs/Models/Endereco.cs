using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class Endereco
    {
        public Endereco()
        {
            Compras = new HashSet<Compra>();
        }

        public int EnderecoId { get; set; }
        public int TipoEnderecoId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual TipoEndereco TipoEndereco { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
