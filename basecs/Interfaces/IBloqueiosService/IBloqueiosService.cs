using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IBloqueiosService
{
    public interface IBloqueiosService
    {
        #region FIND BY ID
        Task<Bloqueio> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Bloqueio>> ReturnListWithParametersPaginated(int? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Bloqueio>> ReturnListWithParameters(int? id, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<Bloqueio> Insert(Bloqueio model);
        #endregion

        #region UPDATE
        Task<Bloqueio> Update(Bloqueio model);
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        Task<Bloqueio> Delete(int id);
        #endregion
    }
}
