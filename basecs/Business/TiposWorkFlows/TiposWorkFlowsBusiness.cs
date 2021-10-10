using basecs.Helpers.Helpers.Validators;

namespace basecs.Business.TiposWorkflows
{
    public class TiposWorkflowsBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.TipoWorkflow model)
        {
            string validation = "";

            if (model.TipoWorkflowId > 0)
            {
                validation += "Identificação do tipo de workflow invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do workflow contem menos de três caracteres\n";
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
                validation += "Não pode ser adicinado tipo de workflow inativado\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.TipoWorkflow model)
        {
            string validation = "";

            if (model.TipoWorkflowId < 1)
            {
                validation += "Identificação do tipo de workflow invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do workflow contem menos de três caracteres\n";
                }
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
                validation += "Identificação do tipo de workflow invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
