using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.ITiposGarantiasService
{
    public interface ITiposGarantiasService
    {
        #region FIND BY ID
        Task<TipoGarantia> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<TipoGarantia>> ReturnListWithParametersPaginated(int? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<TipoGarantia>> ReturnListWithParameters(int? id, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<TipoGarantia> Insert(TipoGarantia model);
        #endregion

        #region UPDATE
        Task<TipoGarantia> Update(TipoGarantia model);
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        Task<TipoGarantia> Delete(int id);
        #endregion
    }
}
