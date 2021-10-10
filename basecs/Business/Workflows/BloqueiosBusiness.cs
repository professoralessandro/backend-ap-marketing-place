using basecs.Helpers.Helpers.Validators;

namespace basecs.Business.Workflows
{
    public class WorkflowsBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Workflow model)
        {
            string validation = "";

            if (model.WorkflowId > 0)
            {
                validation += "Identificação do bloqueios invalido\n";
            }

            if (model.TipoWorkflowId < 1)
            {
                validation += "Identificação do tipo de workflow invalido\n";
            }

            if (model.StatusAprovacaoId < 1)
            {
                validation += "Identificação do status do workflow invalido\n";
            }

            if (model.UsuarioResponsavel < 1)
            {
                validation += "Identificação do usuario responsavel pelo workflow invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do bloqueios contem menos de três caracteres\n";
                }
            }

            if (model.UsuarioInclusaoId < 1)
            {
                validation += "Identificação do usuario que incluiu e invalido\n";
            }

            if (model.UsuarioUltimaAlteracaoId < 1)
            {
                validation += "Identificação do usuario que incluiu e invalido\n";
            }

            if (!model.Ativo)
            {
                validation += "Não pode ser adicinado bloqueio inativado\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Workflow model)
        {
            string validation = "";

            if (model.WorkflowId < 1)
            {
                validation += "Identificação do bloqueios invalido\n";
            }

            if (model.TipoWorkflowId < 1)
            {
                validation += "Identificação do tipo de workflow invalido\n";
            }

            if (model.StatusAprovacaoId < 1)
            {
                validation += "Identificação do status do workflow invalido\n";
            }

            if (model.UsuarioResponsavel < 1)
            {
                validation += "Identificação do usuario responsavel pelo workflow invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do bloqueios contem menos de três caracteres\n";
                }
            }

            if (model.UsuarioInclusaoId < 1)
            {
                validation += "Identificação do usuario que incluiu e invalido\n";
            }

            if (model.UsuarioUltimaAlteracaoId < 1)
            {
                validation += "Identificação do usuario que incluiu e invalido\n";
            }

            return validation;
        }
        #endregion

        #region DELETE
        public string DeleteValidation(int id)
        {
            string validation = "";

            if (id < 1)
            {
                validation += "Identificação do bloqueios invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
