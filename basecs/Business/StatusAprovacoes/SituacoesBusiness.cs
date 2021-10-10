using basecs.Helpers.Helpers.Validators;

namespace basecs.Business.StatusAprovacoes
{
    public class StatusAprovacoesBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.StatusAprovacao model)
        {
            string validation = "";

            if (model.StatusAprovacaoId > 0)
            {
                validation += "Identificação do tipo de bloqueio invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do bloqueio contem menos de três caracteres\n";
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
                validation += "Não pode ser adicinado tipo de bloqueio inativado\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.StatusAprovacao model)
        {
            string validation = "";

            if (model.StatusAprovacaoId == 0)
            {
                validation += "Identificação do tipo de bloqueio invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do bloqueio contem menos de três caracteres\n";
                }
            }

            if (model.UsuarioUltimaAlteracaoId < 1)
            {
                validation += "Identificação do usuario que incluiu e invalido\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string DeleteValidation(int id)
        {
            string validation = "";

            if (id < 1)
            {
                validation += "Identificação do tipo de bloqueio invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
