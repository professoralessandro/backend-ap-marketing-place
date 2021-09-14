using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class TiposEndereco
    {
        public TiposEndereco()
        {
            Enderecos = new HashSet<Endereco>();
        }

        public int TipoEnderecoId { get; set; }
        public string Descricao { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
