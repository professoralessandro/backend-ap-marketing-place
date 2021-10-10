using System;
using System.Collections.Generic;

#nullable disable

namespace basecs.Models
{
    public partial class Workflow
    {
        public int WorkflowId { get; set; }
        public int TipoWorkflowId { get; set; }
        public int StatusAprovacaoId { get; set; }
        public int UsuarioResponsavel { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public DateTime? DataWorkflowVerificacao { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public int UsuarioUltimaAlteracaoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public bool Ativo { get; set; }

        public virtual StatusAprovacao StatusAprovacao { get; set; }
        public virtual TipoWorkflow TipoWorkflow { get; set; }
    }
}
