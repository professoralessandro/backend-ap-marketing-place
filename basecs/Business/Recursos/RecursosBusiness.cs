using basecs.Helpers.Helpers.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Business.Recursos
{
    public class RecursosBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Recurso model)
        {
            string validation = "";

            if (model.RecursoId > 0)
            {
                validation += "Identificação do bloqueios invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Nome))
            {
                model.Nome = Validators.RemoveInjections(model.Nome);
                if (model.Nome.Length < 3)
                {
                    validation += "Descrição do recurso contem menos de três caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Chave))
            {
                model.Chave = Validators.RemoveInjections(model.Chave);
                if (model.Chave.Length < 3)
                {
                    validation += "Chave do recurso contem menos de três caracteres\n";
                }
            }

            if (model.IsSubMenu.Equals(null))
            {
                validation += "Deve ser informado se o recurso e um submenu\n";
            }

            if (!model.Ativo)
            {
                validation += "Não pode ser adicinado bloqueio inativado\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Recurso model)
        {
            string validation = "";

            if (model.RecursoId < 1)
            {
                validation += "Identificação do bloqueios invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Nome))
            {
                model.Nome = Validators.RemoveInjections(model.Nome);
                if (model.Nome.Length < 3)
                {
                    validation += "Descrição do recurso contem menos de três caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Chave))
            {
                model.Chave = Validators.RemoveInjections(model.Chave);
                if (model.Chave.Length < 3)
                {
                    validation += "Chave do recurso contem menos de três caracteres\n";
                }
            }

            if (model.IsSubMenu.Equals(null))
            {
                validation += "Deve ser informado se o recurso e um submenu\n";
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
