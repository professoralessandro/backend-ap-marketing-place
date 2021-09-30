using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.ITiposCaracteristicasService
{
    public interface ITiposCaracteristicasService
    {
        #region FIND BY ID
        Task<TipoCaracteristica> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<TipoCaracteristica>> ReturnListWithParametersPaginated(int? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<TipoCaracteristica>> ReturnListWithParameters(int? id, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<TipoCaracteristica> Insert(TipoCaracteristica model);
        #endregion

        #region UPDATE
        Task<TipoCaracteristica> Update(TipoCaracteristica model);
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        Task<TipoCaracteristica> Delete(int id);
        #endregion
    }
}
