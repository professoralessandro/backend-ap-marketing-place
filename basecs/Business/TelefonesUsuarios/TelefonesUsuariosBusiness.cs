
namespace basecs.Business.TelefonesUsuarios
{
    public class TelefonesUsuariosBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.TelefoneUsuario model)
        {
            string validation = "";

            if (model.TelefoneUsuarioId > 0)
            {
                validation += "Identificação da telefone usuario invalido\n";
            }

            if (model.TelefoneId < 1)
            {
                validation += "Identificação do endereço que incluiu e invalido\n";
            }

            if (model.UsuarioId < 1)
            {
                validation += "Identificação da nova configuração parametro e invalido\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.TelefoneUsuario model)
        {
            string validation = "";

            if (model.TelefoneUsuarioId < 1)
            {
                validation += "Identificação da configuração invalido\n";
            }

            if (model.TelefoneId < 1)
            {
                validation += "Identificação do endereço que incluiu e invalido\n";
            }

            if (model.UsuarioId < 1)
            {
                validation += "Identificação da nova configuração parametro e invalido\n";
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
                validation += "Identificação da configuração invalido\n";
            }

            return validation;
        }
        #endregion
    }
}
