﻿using basecs.Helpers.Helpers.Validators;

namespace basecs.Business.Lancamentos
{
    public class LancamentosBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Lancamento model)
        {
            string validation = "";

            if (model.LancamentoId > 0)
            {
                validation += "Identificação do regristro invalido\n";
            }

            if (!string.IsNullOrEmpty(model.File))
            {
                model.File = Validators.RemoveInjections(model.File);
                if (model.File.Length < 3)
                {
                    validation += "O arquivo contem menos de três caracteres\n";
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

            if (model.Publico.Equals(null))
            {
                validation += "O campo publico deve ser informado\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.Lancamento model)
        {
            string validation = "";

            if (model.LancamentoId < 1)
            {
                validation += "Identificação do regristro invalido\n";
            }

            if (!string.IsNullOrEmpty(model.File))
            {
                model.File = Validators.RemoveInjections(model.File);
                if (model.File.Length < 3)
                {
                    validation += "O arquivo contem menos de três caracteres\n";
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

            if (model.Publico.Equals(null))
            {
                validation += "O campo publico deve ser informado\n";
            }

            return validation;
        }
        #endregion

        #region DELETE
        public string DeleteValidation(int id)
        {
            string validation = "";

            if (id == 0)
            {
                validation += "Identificação do registro invalida\n";
            }

            return validation;
        }
        #endregion
    }
}
