using basecs.Dtos.Usuarios;
using basecs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.Services.IUsuariosService
{
    public interface IUsuariosService
    {
        #region FIND BY ID
        Task<Usuario> FindById(Guid id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Usuario>> ReturnListWithParametersPaginated(Guid? id, string nome, string nmrDocumento, string email, bool? ativo, int? pageNumber, int? rowspPage);
        Task<IEnumerable<UsuarioDto>> ReturnUsersWithParametersPaginated(
                Guid? id,
                string nome,
                string nmrDocumento,
                string email,
                bool? ativo,
                int? pageNumber,
                int? rowspPage
            );
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Usuario>> ReturnListWithParameters(Guid? id, string nome, string nmrDocumento, string email, bool? ativo);
        #endregion

        #region INSERT
        Task<int> Insert(InsertUserDto model);
        #endregion

        #region UPDATE
        Task<Usuario> Update(Usuario model);
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        Task<Usuario> Delete(Guid id);
        #endregion
    }
}
