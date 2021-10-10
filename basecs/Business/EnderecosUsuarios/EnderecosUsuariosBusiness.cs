
namespace basecs.Business.EnderecosUsuarios
{
    public class EnderecosUsuariosBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.EnderecoUsuario model)
        {
            string validation = "";

            if (model.EnderecoUsuarioId > 0)
            {
                validation += "Identificação da configuração invalido\n";
            }

            if (model.EnderecoId < 1)
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
        public string UpdateValidation(basecs.Models.EnderecoUsuario model)
        {
            string validation = "";

            if (model.EnderecoUsuarioId < 1)
            {
                validation += "Identificação da configuração invalido\n";
            }

            if (model.EnderecoId < 1)
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
