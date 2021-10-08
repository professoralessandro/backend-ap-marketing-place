using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IImagensProdutosService
{
    public interface IImagensProdutosService
    {
        #region FIND BY ID
        Task<ImagemProduto> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<ImagemProduto>> ReturnListWithParametersPaginated(int? id, int? configuracaoId, int? parametroId, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<ImagemProduto>> ReturnListWithParameters(int? id, int? configuracaoId, int? parametroId);
        #endregion

        #region INSERT
        Task<ImagemProduto> Insert(ImagemProduto model);
        #endregion

        #region UPDATE
        Task<ImagemProduto> Update(ImagemProduto model);
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        Task<ImagemProduto> Delete(int id);
        #endregion
    }
}
