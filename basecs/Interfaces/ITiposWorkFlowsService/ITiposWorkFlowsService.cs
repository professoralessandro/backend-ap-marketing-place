using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.ITiposWorkflowsService
{
    public interface ITiposWorkflowsService
    {
        #region FIND BY ID
        Task<TipoWorkflow> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<TipoWorkflow>> ReturnListWithParametersPaginated(int? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<TipoWorkflow>> ReturnListWithParameters(int? id, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<TipoWorkflow> Insert(TipoWorkflow model);
        #endregion

        #region UPDATE
        Task<TipoWorkflow> Update(TipoWorkflow model);
        #endregion        

        #region DELETE
        Task<TipoWorkflow> Delete(int id);
        #endregion
    }
}
