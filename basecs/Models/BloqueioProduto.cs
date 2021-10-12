#nullable disable

namespace basecs.Models
{
    public partial class BloqueioProduto
    {
        public int BloqueioProdutoId { get; set; }
        public int BloqueioId { get; set; }
        public int ProdutoId { get; set; }

        public virtual Bloqueio Bloqueio { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
