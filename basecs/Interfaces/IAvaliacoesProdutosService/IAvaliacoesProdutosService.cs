

using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IAvaliacoesProdutosService
{
    public interface IAvaliacoesProdutosService
    {
        #region FIND BY ID
        Task<AvaliacaoProduto> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<AvaliacaoProduto>> ReturnListWithParametersPaginated(int? id, int? telefoneId, int? usuarioId, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<AvaliacaoProduto>> ReturnListWithParameters(int? id, int? telefoneId, int? usuarioId);
        #endregion

        #region INSERT
        Task<AvaliacaoProduto> Insert(AvaliacaoProduto model);
        #endregion

        #region UPDATE
        Task<AvaliacaoProduto> Update(AvaliacaoProduto model);
        #endregion        

        #region DELETE
        Task<AvaliacaoProduto> Delete(int id);
        #endregion
    }
}
