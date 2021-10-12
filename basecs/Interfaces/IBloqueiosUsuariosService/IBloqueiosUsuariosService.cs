

using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IBloqueiosUsuariosService
{
    public interface IBloqueiosUsuariosService
    {
        #region FIND BY ID
        Task<BloqueioUsuario> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<BloqueioUsuario>> ReturnListWithParametersPaginated(int? id, int? telefoneId, int? usuarioId, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<BloqueioUsuario>> ReturnListWithParameters(int? id, int? telefoneId, int? usuarioId);
        #endregion

        #region INSERT
        Task<BloqueioUsuario> Insert(BloqueioUsuario model);
        #endregion

        #region UPDATE
        Task<BloqueioUsuario> Update(BloqueioUsuario model);
        #endregion        

        #region DELETE
        Task<BloqueioUsuario> Delete(int id);
        #endregion
    }
}
