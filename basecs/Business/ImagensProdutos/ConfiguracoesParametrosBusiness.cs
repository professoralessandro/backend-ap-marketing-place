
namespace basecs.Business.ImagensProdutos
{
    public class ImagensProdutosBusiness
    {
        #region INSERT
        public string InsertValidation(basecs.Models.ImagemProduto model)
        {
            string validation = "";

            if (model.ImagemProdutoId > 0)
            {
                validation += "Identificação do regristro invalido\n";
            }

            if (model.ProdutoId < 1)
            {
                validation += "Identificação do produto e invalida\n";
            }

            if (model.ImagemId < 1)
            {
                validation += "Identificação da imagem e invalida\n";
            }

            return validation;
        }
        #endregion

        #region UPDATE
        public string UpdateValidation(basecs.Models.ImagemProduto model)
        {
            string validation = "";

            if (model.ImagemProdutoId < 1)
            {
                validation += "Identificação do regristro invalido\n";
            }

            if (model.ProdutoId < 1)
            {
                validation += "Identificação do produto e invalida\n";
            }

            if (model.ImagemId < 1)
            {
                validation += "Identificação da imagem e invalida\n";
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
