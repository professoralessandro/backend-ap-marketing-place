using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.ITiposBloqueiosService
{
    public interface ITiposBloqueiosService
    {
        #region FIND BY ID
        Task<TipoBloqueio> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<TipoBloqueio>> ReturnListWithParametersPaginated(int? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<TipoBloqueio>> ReturnListWithParameters(int? id, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<TipoBloqueio> Insert(TipoBloqueio model);
        #endregion

        #region UPDATE
        Task<TipoBloqueio> Update(TipoBloqueio model);
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        Task<TipoBloqueio> Delete(int id);
        #endregion
    }
}