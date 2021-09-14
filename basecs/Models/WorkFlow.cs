using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class WorkFlow
    {
        public int WorkFlowId { get; set; }
        public int TipoWorkflowId { get; set; }
        public int StatusAprovacaoId { get; set; }
        public int UsuarioResponsavel { get; set; }
        public DateTime DataWorkFlow { get; set; }
        public string Observacao { get; set; }
        public DateTime? DataWorkFlowVerificacao { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual StatusAprovaco StatusAprovacao { get; set; }
        public virtual TipoWorkFlow TipoWorkflow { get; set; }
    }
}
