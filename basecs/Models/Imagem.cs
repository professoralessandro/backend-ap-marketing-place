using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class Imagem
    {
        public Imagem()
        {
            ImagensProdutos = new HashSet<ImagemProduto>();
        }

        public int ImagemId { get; set; }
        public string Imagem { get; set; }
        public string Descricao { get; set; }
        public bool ImagemPrincipal { get; set; }
        public bool Publico { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }

        public virtual ICollection<ImagemProduto> ImagensProdutos { get; set; }
    }
}
