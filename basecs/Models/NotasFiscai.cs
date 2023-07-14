
#nullable disable

using basecs.Enuns;
using System;

namespace basecs.Models
{
    public partial class NotasFiscai
    {
        public Guid NotaFiscalId { get; set; }

        public TipoNotaFiscalEnum TipoNotaFiscal { get; set; }
    }
}
