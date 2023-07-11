using basecs.Helpers.Helpers.Validators;
using basecs.Interfaces.Business.IAvaliacoesBusiness;

namespace basecs.Business.Telefones
{
    public class TelefonesBusiness : ITelefonesBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Telefone model)
        {
            string validation = "";

            if (model.TelefoneId > 0)
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
        public string UpdateValidation(basecs.Models.Telefone model)
        {
            string validation = "";

            if (model.TelefoneId == 0)
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

            if (model.UsuarioUltimaAlteracaoId < 1)
            {
                validation += "Identificacao do usuario que incluiu e invalido\n";
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
                validation += "Identificação do avaliação invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
