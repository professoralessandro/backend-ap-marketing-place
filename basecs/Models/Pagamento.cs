
#nullable disable

using System;

namespace basecs.Models
{
    public partial class Pagamento
    {
        public Guid PagamentoId { get; set; }

        public int? LancamentoId { get; set; }
    }
}
