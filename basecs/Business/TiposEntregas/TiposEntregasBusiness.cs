﻿using basecs.Helpers.Helpers.Validators;

namespace basecs.Business.TiposEntregas
{
    public class TiposEntregasBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.TipoEntrega model)
        {
            string validation = "";

            if (model.TipoEntregaId > 0)
            {
                validation += "Identificação do tipo de entrega invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = model.Descricao.RemoveInjections();
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do entrega contem menos de três caracteres\n";
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
        public string UpdateValidation(basecs.Models.TipoEntrega model)
        {
            string validation = "";

            if (model.TipoEntregaId == 0)
            {
                validation += "Identificação do tipo de entrega invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Descricao))
            {
                model.Descricao = model.Descricao.RemoveInjections();
                if (model.Descricao.Length < 3)
                {
                    validation += "Descrição do entrega contem menos de três caracteres\n";
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
                validation += "Identificação do tipo de entrega invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
