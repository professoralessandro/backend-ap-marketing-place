﻿using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class TiposNotasFiscai
    {
        public TiposNotasFiscai()
        {
            NotasFiscais = new HashSet<NotasFiscai>();
        }

        public int TipoNotaFiscalId { get; set; }
        public string Descricao { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<NotasFiscai> NotasFiscais { get; set; }
    }
}
