using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.ITiposEnderecosService
{
    public interface ITiposEnderecosService
    {
        #region FIND BY ID
        Task<TipoEndereco> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<TipoEndereco>> ReturnListWithParametersPaginated(int? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<TipoEndereco>> ReturnListWithParameters(int? id, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<TipoEndereco> Insert(TipoEndereco model);
        #endregion

        #region UPDATE
        Task<TipoEndereco> Update(TipoEndereco model);
        #endregion        

        #region DELETE
        Task<TipoEndereco> Delete(int id);
        #endregion
    }
}
