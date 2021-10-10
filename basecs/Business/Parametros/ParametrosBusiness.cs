using basecs.Helpers.Helpers.Validators;

namespace basecs.Business.Parametros
{
    public class ParametrosBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Parametro model)
        {
            string validation = "";

            if (model.ParametroId > 0)
            {
                validation += "Identificação do bloqueios invalido\n";
            }

            if (model.TipoParametroId < 1)
            {
                validation += "Identificação tipo de patametro que incluiu e invalido\n";
            }

            if (model.TipoDadoId < 1)
            {
                validation += "Identificação tipo de dado que incluiu e invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do bloqueios contem menos de três caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Valor))
            {
                model.Valor = Validators.RemoveInjections(model.Valor);
                if (model.Valor.Length < 3)
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
        public string UpdateValidation(basecs.Models.Parametro model)
        {
            string validation = "";

            if (model.ParametroId < 1)
            {
                validation += "Identificação do bloqueios invalido\n";
            }

            if (model.TipoParametroId < 1)
            {
                validation += "Identificação tipo de patametro que incluiu e invalido\n";
            }

            if (model.TipoDadoId < 1)
            {
                validation += "Identificação tipo de dado que incluiu e invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do bloqueios contem menos de três caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Valor))
            {
                model.Valor = Validators.RemoveInjections(model.Valor);
                if (model.Valor.Length < 3)
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
