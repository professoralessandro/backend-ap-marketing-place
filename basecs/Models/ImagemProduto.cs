using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class ImagemProduto
    {
        public int ImagemProdutoId { get; set; }
        public int ImagemId { get; set; }
        public int ProdutoId { get; set; }

        public virtual Imagen Imagem { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
