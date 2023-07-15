using basecs.Enuns;
using System;

#nullable disable

namespace basecs.Models
{
    public partial class WorkFlowDto
    {
        public Guid WorkFlowId { get; set; }

        public TipoWorkFlowEnum TipoWorkflow { get; set; }

        public StatusAprovacoEnum StatusAprovacaoId { get; set; }

        public int UsuarioResponsavel { get; set; }

        public DateTime DataWorkFlow { get; set; }

        public string Observacao { get; set; }

        public DateTime? DataWorkFlowVerificacao { get; set; }

        public Guid UsuarioInclusaoId { get; set; }

        public Guid? UsuarioUltimaAlteracaoId { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataUltimaAlteracao { get; set; }

        public bool Ativo { get; set; }
    }
}
