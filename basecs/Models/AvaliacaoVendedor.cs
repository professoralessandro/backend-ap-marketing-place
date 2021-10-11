#nullable disable

namespace basecs.Models
{
    public partial class AvaliacaoVendedor
    {
        public int AvaliacaoVendedorId { get; set; }
        public int AvaliacaoId { get; set; }
        public int VendedorId { get; set; }

        public virtual Avaliacao Avaliacao { get; set; }
        public virtual Usuario Vendedor { get; set; }
    }
}
