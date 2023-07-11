using basecs.Dtos.Usuarios;
using System.Threading.Tasks;

namespace basecs.Interfaces.Repository
{
    public interface IUsuariosRepository
    {
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
