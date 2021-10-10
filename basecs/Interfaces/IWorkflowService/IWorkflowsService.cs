using basecs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IWorkflowsService
{
    public interface IWorkflowsService
    {
        #region FIND BY ID
        Task<Workflow> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Workflow>> ReturnListWithParametersPaginated(int? id, int? tipoWorkflowId, int? statusAprovacaoId, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Workflow>> ReturnListWithParameters(int? id, int? tipoWorkflowId, int? statusAprovacaoId, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<Workflow> Insert(Workflow model);
        #endregion

        #region UPDATE
        Task<Workflow> Update(Workflow model);
        #endregion        

        #region DELETE
        Task<Workflow> Delete(int id);
        #endregion
    }
}
