using basecs.Helpers.Helpers.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição da configuração contem menos de três caracteres\n";
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

        #region UPDATE
        public string UpdateValidation(basecs.Models.Configuracao model)
        {
            string validation = "";

            if (model.ConfiguracaoId == 0)
            {
                validation += "Identificação da configuração invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição da configuração contem menos de três caracteres\n";
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

            if (id == 0)
            {
                validation += "Identificação da configuração invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
