using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.ITiposLancamentosService
{
    public interface ITiposLancamentosService
    {
        #region FIND BY ID
        Task<TipoLancamento> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<TipoLancamento>> ReturnListWithParametersPaginated(int? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<TipoLancamento>> ReturnListWithParameters(int? id, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<TipoLancamento> Insert(TipoLancamento model);
        #endregion

        #region UPDATE
        Task<TipoLancamento> Update(TipoLancamento model);
        #endregion        

        #region DELETE
        Task<TipoLancamento> Delete(int id);
        #endregion
    }
}
