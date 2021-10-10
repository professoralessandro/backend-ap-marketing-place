using basecs.Models;
using System;
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
        Task<List<Usuario>> ReturnListWithParametersPaginated(string param, DateTime? dateAdded, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Usuario>> ReturnListWithParameters(int? id, int? grupoUsaruiId, string login, string nome, string email, bool? bloqueada, bool? ativo);
        #endregion

        #region INSERT
        Task<Usuario> Insert(Usuario model);
        #endregion

        #region UPDATE
        Task<Usuario> Update(Usuario model);
        #endregion        

        #region DELETE
        Task<Usuario> Delete(int id);
        #endregion
    }
}
