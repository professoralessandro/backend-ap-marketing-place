﻿using basecs.Helpers.Helpers.Validators;

namespace basecs.Business.TiposBloqueios
{
    public class TiposBloqueiosBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.TipoBloqueio model)
        {
            string validation = "";

            if (model.TipoBloqueioId > 0)
            {
                validation += "Identificação do tipo de dado invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 2)
                {
                    validation += "Descrição do dado contem menos de dois caracteres\n";
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
        public string UpdateValidation(basecs.Models.TipoBloqueio model)
        {
            string validation = "";

            if (model.TipoBloqueioId == 0)
            {
                validation += "Identificação do tipo de dado invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = Validators.RemoveInjections(model.Descricao);
                if (model.Descricao.Length < 2)
                {
                    validation += "Descrição do dado contem menos de dois caracteres\n";
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
                validation += "Identificação do tipo de dado invalido\n";
            }

            return validation;
        }
        #endregion
    }
}