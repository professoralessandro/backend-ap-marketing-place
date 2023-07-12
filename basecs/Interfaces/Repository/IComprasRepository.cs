using basecs.Dtos.Compras;
using basecs.Dtos.Usuarios;
using System.Threading.Tasks;

namespace basecs.Interfaces.Repository
{
    public interface IComprasRepository
    {
        #region INSERT
        public Task<int> InsertUserAsync(InsertCompraDto model);
        #endregion

        #region UPDATE
        public Task<int> UpdateValidation(EditCompraDto model);
        #endregion

        #region DELETE
        public Task<int> DeleteUserAsync(int id);
        #endregion
    }
}
