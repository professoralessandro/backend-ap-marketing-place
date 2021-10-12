using basecs.Helpers.Helpers.Validators;

namespace basecs.Business.Configuracoes
{
    public class ConfiguracoesBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Configuracao model)
        {
            string validation = "";

            if (model.ConfiguracaoId > 0)
            {
                validation += "Identificação do configuracaos invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3 && model.Descricao.Length > 150)
                {
                    validation += "Descrição da configuração contem menos de três ou mais de cento e cinquenta caracteres\n";
                }
            }

            if (string.IsNullOrEmpty(model.Descricao))
            {
                validation += "Descrição da configuração nao pode ser vazia\n";
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
                validation += "Não pode ser adicinado tipo de configuração inativado\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Configuracao model)
        {
            string validation = "";

            if (model.ConfiguracaoId < 1)
            {
                validation += "Identificação da configuração invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3 && model.Descricao.Length > 150)
                {
                    validation += "Descrição da configuração contem menos de três ou mais de cento e cinquenta caracteres\n";
                }
            }

            if (string.IsNullOrEmpty(model.Descricao))
            {
                validation += "Descrição da configuração nao pode ser vazia\n";
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
                validation += "Identificação da configuração invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
