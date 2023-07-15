#nullable disable

using System;

namespace basecs.Models
{
    public partial class PagamentoDto
    {
        public Guid PagamentoId { get; set; }

        public int? LancamentoId { get; set; }
    }
}
