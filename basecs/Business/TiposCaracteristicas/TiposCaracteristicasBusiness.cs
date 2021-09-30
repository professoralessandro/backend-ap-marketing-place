using basecs.Helpers.Helpers.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Business.TiposCaracteristicas
{
    public class TiposCaracteristicasBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.TipoCaracteristica model)
        {
            string validation = "";

            if (model.TipoCaracteristicaId > 0)
            {
                validation += "Identificação do tipo de caracteristica invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 2)
                {
                    validation += "Descrição do caracteristica contem menos de dois caracteres\n";
                }
            }

            if (model.UsuarioInclusaoId < 1)
            {
                validation += "Identificação do usuario que incluiu e invalido\n";
            }

            if (model.UsuarioUltimaAlteracaoId < 1)
            {
                validation += "Identificacao do usuario que incluiu e invalido\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.TipoCaracteristica model)
        {
            string validation = "";

            if (model.TipoCaracteristicaId == 0)
            {
                validation += "Identificação do tipo de caracteristica invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 2)
                {
                    validation += "Descrição do caracteristica contem menos de dois caracteres\n";
                }
            }

            if (model.UsuarioUltimaAlteracaoId < 1)
            {
                validation += "Identificacao do usuario que incluiu e invalido\n";
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
                validation += "Identificação do tipo de caracteristica invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
