using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.Business.IAvaliacoesBusiness;
using System;

namespace basecs.Business.Configuracoes
{
    public class ConfiguracoesBusiness : IConfiguracoesBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Configuracao model)
        {
            string validation = "";

            if (model.ConfiguracaoId == Guid.Empty)
            {
                validation += "Identificação do configuracaos invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = model.Descricao.RemoveInjections();
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição da configuração contem menos de três caracteres\n";
                }
            }

            if (model.UsuarioInclusaoId == Guid.Empty)
            {
                validation += "Identificação do usuario que incluiu e invalido\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Configuracao model)
        {
            string validation = "";

            if (model.ConfiguracaoId == Guid.Empty)
            {
                validation += "Identificação da configuração invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = model.Descricao.RemoveInjections();
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição da configuração contem menos de três caracteres\n";
                }
            }

            if (model.UsuarioUltimaAlteracaoId == Guid.Empty)
            {
                validation += "Identificação do usuario que incluiu e invalido\n";
            }

            return validation;
        }
        #endregion

        #region DELETE
        public string DeleteValidation(Guid id)
        {
            string validation = "";

            if (id == Guid.Empty)
            {
                validation += "Identificação da configuração invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
