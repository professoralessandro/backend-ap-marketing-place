
namespace basecs.Business.AvaliacoesVendedores
{
    public class AvaliacoesVendedoresBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.AvaliacaoVendedor model)
        {
            string validation = "";

            if (model.AvaliacaoVendedorId > 0)
            {
                validation += "Identificação da configuração invalido\n";
            }

            if (model.AvaliacaoId < 1)
            {
                validation += "Identificação da avaliacao que incluiu e invalido\n";
            }

            if (model.VendedorId < 1)
            {
                validation += "Identificação do vendedor que incluiu e invalido\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.AvaliacaoVendedor model)
        {
            string validation = "";

            if (model.AvaliacaoVendedorId < 1)
            {
                validation += "Identificação da configuração invalido\n";
            }

            if (model.AvaliacaoId < 1)
            {
                validation += "Identificação da avaliacao que incluiu e invalido\n";
            }

            if (model.VendedorId < 1)
            {
                validation += "Identificação do vendedor que incluiu e invalido\n";
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
