﻿
#nullable disable

namespace basecs.Models
{
    public partial class NotasFiscai
    {
        public int NotaFiscalId { get; set; }
        public int TipoNotaFiscalId { get; set; }

        public virtual TipoNotaFiscal TipoNotaFiscal { get; set; }
    }
}
