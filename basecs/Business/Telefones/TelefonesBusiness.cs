using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.Business.IAvaliacoesBusiness;
using System;

namespace basecs.Business.Telefones
{
    public class TelefonesBusiness : ITelefonesBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Telefone model)
        {
            string validation = "";

            if (model.TelefoneId == Guid.Empty)
            {
                validation += "Identificação do avaliação invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Numero))
            {
                model.Numero = model.Numero.RemoveInjections();
                if (model.Numero.Length < 3)
                {
                    validation += "Descrição do avaliação contem menos de três caracteres\n";
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
        public string UpdateValidation(basecs.Models.Telefone model)
        {
            string validation = "";

            if (model.TelefoneId == Guid.Empty)
            {
                validation += "Identificação do avaliação invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Numero))
            {
                model.Numero = Validators.RemoveInjections(model.Numero);
                if (model.Numero.Length < 3)
                {
                    validation += "Descrição do avaliação contem menos de três caracteres\n";
                }
            }

            if (model.UsuarioUltimaAlteracaoId == Guid.Empty)
            {
                validation += "Identificacao do usuario que incluiu e invalido\n";
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
                validation += "Identificação do avaliação invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
