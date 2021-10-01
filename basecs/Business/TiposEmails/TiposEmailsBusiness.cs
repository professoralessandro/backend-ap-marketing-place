﻿using basecs.Helpers.Helpers.Validators;

namespace basecs.Business.Tipoemails
{
    public class TiposEmailsBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.TipoEmail model)
        {
            string validation = "";

            if (model.TipoEmailId > 0)
            {
                validation += "Identificação do tipo de email invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 2)
                {
                    validation += "Descrição do tipo de email contem menos de dois caracteres\n";
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
        public string UpdateValidation(basecs.Models.TipoEmail model)
        {
            string validation = "";

            if (model.TipoEmailId == 0)
            {
                validation += "Identificação do tipo de email invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 2)
                {
                    validation += "Descrição do tipo de email contem menos de dois caracteres\n";
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
                validation += "Identificação do tipo de email invalido\n";
            }

            return validation;
        }
        #endregion
    }
}