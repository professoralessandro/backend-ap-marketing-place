using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.ITiposWorkFlowsService
{
    public interface ITiposWorkFlowsService
    {
        #region FIND BY ID
        Task<TipoWorkFlow> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<TipoWorkFlow>> ReturnListWithParametersPaginated(int? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<TipoWorkFlow>> ReturnListWithParameters(int? id, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<TipoWorkFlow> Insert(TipoWorkFlow model);
        #endregion

        #region UPDATE
        Task<TipoWorkFlow> Update(TipoWorkFlow model);
        #endregion        

        #region DELETE
        Task<TipoWorkFlow> Delete(int id);
        #endregion
    }
}
