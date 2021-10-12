#nullable disable

namespace basecs.Models
{
    public partial class AvaliacaoProduto
    {
        public int AvaliacaoProdutoId { get; set; }
        public int AvaliacaoId { get; set; }
        public int ProdutoId { get; set; }

        public virtual Avaliacao Avaliacao { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
