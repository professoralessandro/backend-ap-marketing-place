

using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.ITelefonesUsuariosService
{
    public interface ITelefonesUsuariosService
    {
        #region FIND BY ID
        Task<TelefoneUsuario> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<TelefoneUsuario>> ReturnListWithParametersPaginated(int? id, int? telefoneId, int? usuarioId, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<TelefoneUsuario>> ReturnListWithParameters(int? id, int? telefoneId, int? usuarioId);
        #endregion

        #region INSERT
        Task<TelefoneUsuario> Insert(TelefoneUsuario model);
        #endregion

        #region UPDATE
        Task<TelefoneUsuario> Update(TelefoneUsuario model);
        #endregion        

        #region DELETE
        Task<TelefoneUsuario> Delete(int id);
        #endregion
    }
}
