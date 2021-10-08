using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.ITiposProdutosService
{
    public interface ITiposProdutosService
    {
        #region FIND BY ID
        Task<TipoProduto> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<TipoProduto>> ReturnListWithParametersPaginated(int? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<TipoProduto>> ReturnListWithParameters(int? id, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<TipoProduto> Insert(TipoProduto model);
        #endregion

        #region UPDATE
        Task<TipoProduto> Update(TipoProduto model);
        #endregion        

        #region DELETE
        Task<TipoProduto> Delete(int id);
        #endregion
    }
}
