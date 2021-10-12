
namespace basecs.Business.BloqueiosUsuarios
{
    public class BloqueiosUsuariosBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.BloqueioUsuario model)
        {
            string validation = "";

            if (model.BloqueioUsuarioId > 0)
            {
                validation += "Identificação da configuração invalido\n";
            }

            if (model.BloqueioId < 1)
            {
                validation += "Identificação da avaliacao que incluiu e invalido\n";
            }

            if (model.UsuarioId < 1)
            {
                validation += "Identificação do produto que incluiu e invalido\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.BloqueioUsuario model)
        {
            string validation = "";

            if (model.BloqueioUsuarioId < 1)
            {
                validation += "Identificação da configuração invalido\n";
            }

            if (model.BloqueioId < 1)
            {
                validation += "Identificação da avaliacao que incluiu e invalido\n";
            }

            if (model.UsuarioId < 1)
            {
                validation += "Identificação do produto que incluiu e invalido\n";
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
