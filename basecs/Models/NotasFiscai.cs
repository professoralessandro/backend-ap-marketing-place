
#nullable disable

using basecs.Enuns;

namespace basecs.Models
{
    public partial class NotasFiscai
    {
        public int NotaFiscalId { get; set; }
        public TipoNotaFiscalEnum TipoNotaFiscal { get; set; }
    }
}
