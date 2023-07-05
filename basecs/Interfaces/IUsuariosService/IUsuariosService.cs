using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IUsuariosService
{
    public interface IUsuariosService
    {
        #region FIND BY ID
        Task<Usuario> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Usuario>> ReturnListWithParametersPaginated(int? id, string nome, string email, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Usuario>> ReturnListWithParameters(int? id, string descricao, string email, bool? ativo);
        #endregion

        #region INSERT
        Task<Usuario> Insert(Usuario model);
        #endregion

        #region UPDATE
        Task<Usuario> Update(Usuario model);
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        Task<Usuario> Delete(int id);
        #endregion
    }
}
