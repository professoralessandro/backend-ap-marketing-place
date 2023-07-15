using basecs.Dtos.Usuarios;
using basecs.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace basecs.Interfaces.Repository
{
    public interface IUsuariosRepository
    {
        #region RETURN LIST WITH PARAMETERS PAGINATED
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

        #region INSERT
        public Task<int> InsertUserAsync(InsertUserDto model);
        #endregion

        #region UPDATE
        public Task<int> UpdateValidation(EditUserDto model);
        #endregion

        #region DELETE
        public Task<int> DeleteUserAsync(int id);
        #endregion
    }
}
