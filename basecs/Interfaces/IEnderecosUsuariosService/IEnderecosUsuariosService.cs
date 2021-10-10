

using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IEnderecosUsuariosService
{
    public interface IEnderecosUsuariosService
    {
        #region FIND BY ID
        Task<EnderecoUsuario> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<EnderecoUsuario>> ReturnListWithParametersPaginated(int? id, int? telefoneId, int? usuarioId, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<EnderecoUsuario>> ReturnListWithParameters(int? id, int? telefoneId, int? usuarioId);
        #endregion

        #region INSERT
        Task<EnderecoUsuario> Insert(EnderecoUsuario model);
        #endregion

        #region UPDATE
        Task<EnderecoUsuario> Update(EnderecoUsuario model);
        #endregion        

        #region DELETE
        Task<EnderecoUsuario> Delete(int id);
        #endregion
    }
}
