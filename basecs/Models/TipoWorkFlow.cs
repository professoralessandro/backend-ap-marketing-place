﻿using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class TipoWorkFlow
    {
        public TipoWorkFlow()
        {
            WorkFlows = new HashSet<WorkFlow>();
        }

        public int TipoWorkFlowId { get; set; }
        public string Descricao { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<WorkFlow> WorkFlows { get; set; }
    }
}
