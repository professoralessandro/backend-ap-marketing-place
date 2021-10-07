

using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.ITiposEntregasService
{
    public interface ITiposEntregasService
    {
        #region FIND BY ID
        Task<TipoEntrega> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<TipoEntrega>> ReturnListWithParametersPaginated(int? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<TipoEntrega>> ReturnListWithParameters(int? id, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<TipoEntrega> Insert(TipoEntrega model);
        #endregion

        #region UPDATE
        Task<TipoEntrega> Update(TipoEntrega model);
        #endregion        

        #region DELETE
        Task<TipoEntrega> Delete(int id);
        #endregion
    }
}
