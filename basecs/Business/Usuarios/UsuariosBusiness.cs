using basecs.Helpers.Helpers.Validators;

namespace basecs.Business.Usuarios
{
    public class UsuariosBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.Usuario model)
        {
            string validation = "";

            if (model.UsuarioId > 0)
            {
                validation += "Identificação do avaliação invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Nome))
            {
                model.Nome = Validators.RemoveInjections(model.Nome);
                if (model.Nome.Length < 3)
                {
                    validation += "Nome contem menos de três caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Email))
            {
                model.Email = Validators.RemoveInjections(model.Email);
                if (model.Email.Length < 3)
                {
                    validation += "Email contem menos de três caracteres\n";
                }

                if (!model.Email.Contains("@"))
                {
                    validation += "Email nao contem @\n";
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
        public string UpdateValidation(basecs.Models.Usuario model)
        {
            string validation = "";

            if (model.UsuarioId == 0)
            {
                validation += "Identificação do avaliação invalido\n";
            }

            if (!string.IsNullOrEmpty(model.Nome))
            {
                model.Nome = Validators.RemoveInjections(model.Nome);
                if (model.Nome.Length < 3)
                {
                    validation += "Nome contem menos de três caracteres\n";
                }
            }

            if (!string.IsNullOrEmpty(model.Email))
            {
                model.Email = Validators.RemoveInjections(model.Email);
                if (model.Email.Length < 3)
                {
                    validation += "Email contem menos de três caracteres\n";
                }

                if (!model.Email.Contains("@"))
                {
                    validation += "Email nao contem @\n";
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
