
namespace basecs.Business.ConfiguracoesParametros
{
    public class ConfiguracoesParametrosBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.ConfiguracaoParametro model)
        {
            string validation = "";

            if (model.ConfiguracaoId > 0)
            {
                validation += "Identificação da configuracao invalido\n";
            }

            if (model.ParametroId < 1)
            {
                validation += "Identificação do parametro que incluiu e invalido\n";
            }

            if (model.ConfiguracaoParametroId < 1)
            {
                validation += "Identificação da nova configuracao parametro e invalido\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.ConfiguracaoParametro model)
        {
            string validation = "";

            if (model.ConfiguracaoId < 1)
            {
                validation += "Identificação da configuracao invalido\n";
            }

            if (model.ParametroId < 1)
            {
                validation += "Identificação do parametro que incluiu e invalido\n";
            }

            if (model.ConfiguracaoParametroId < 1)
            {
                validation += "Identificação da nova configuracao parametro e invalido\n";
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
