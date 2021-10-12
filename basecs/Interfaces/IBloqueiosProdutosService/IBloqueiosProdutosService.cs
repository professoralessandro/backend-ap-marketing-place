

using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IBloqueiosProdutosService
{
    public interface IBloqueiosProdutosService
    {
        #region FIND BY ID
        Task<BloqueioProduto> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<BloqueioProduto>> ReturnListWithParametersPaginated(int? id, int? telefoneId, int? usuarioId, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<BloqueioProduto>> ReturnListWithParameters(int? id, int? telefoneId, int? usuarioId);
        #endregion

        #region INSERT
        Task<BloqueioProduto> Insert(BloqueioProduto model);
        #endregion

        #region UPDATE
        Task<BloqueioProduto> Update(BloqueioProduto model);
        #endregion        

        #region DELETE
        Task<BloqueioProduto> Delete(int id);
        #endregion
    }
}
