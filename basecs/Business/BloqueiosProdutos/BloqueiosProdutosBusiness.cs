
namespace basecs.Business.BloqueiosProdutos
{
    public class BloqueiosProdutosBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.BloqueioProduto model)
        {
            string validation = "";

            if (model.BloqueioProdutoId > 0)
            {
                validation += "Identificação da configuração invalido\n";
            }

            if (model.BloqueioId < 1)
            {
                validation += "Identificação da avaliacao que incluiu e invalido\n";
            }

            if (model.ProdutoId < 1)
            {
                validation += "Identificação do produto que incluiu e invalido\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.BloqueioProduto model)
        {
            string validation = "";

            if (model.BloqueioProdutoId < 1)
            {
                validation += "Identificação da configuração invalido\n";
            }

            if (model.BloqueioId < 1)
            {
                validation += "Identificação da avaliacao que incluiu e invalido\n";
            }

            if (model.ProdutoId < 1)
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
