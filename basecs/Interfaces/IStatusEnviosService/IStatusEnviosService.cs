using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IStatusEnviosService
{
    public interface IStatusEnviosService
    {
        #region FIND BY ID
        Task<StatusEnvio> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<StatusEnvio>> ReturnListWithParametersPaginated(int? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<StatusEnvio>> ReturnListWithParameters(int? id, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<StatusEnvio> Insert(StatusEnvio model);
        #endregion

        #region UPDATE
        Task<StatusEnvio> Update(StatusEnvio model);
        #endregion        

        #region DELETE
        Task<StatusEnvio> Delete(int id);
        #endregion
    }
}
