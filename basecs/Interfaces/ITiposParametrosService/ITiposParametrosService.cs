using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.ITiposParametrosService
{
    public interface ITiposParametrosService
    {
        #region FIND BY ID
        Task<TipoParametro> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<TipoParametro>> ReturnListWithParametersPaginated(int? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<TipoParametro>> ReturnListWithParameters(int? id, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<TipoParametro> Insert(TipoParametro model);
        #endregion

        #region UPDATE
        Task<TipoParametro> Update(TipoParametro model);
        #endregion        

        #region DELETE
        Task<TipoParametro> Delete(int id);
        #endregion
    }
}
