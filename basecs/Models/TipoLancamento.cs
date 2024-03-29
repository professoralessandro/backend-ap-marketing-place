﻿using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class TipoLancamento
    {
        public TipoLancamento()
        {
            Lancamentos = new HashSet<Lancamento>();
        }

        public int TipoLancamentoId { get; set; }
        public string Descricao { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Lancamento> Lancamentos { get; set; }
    }
}
