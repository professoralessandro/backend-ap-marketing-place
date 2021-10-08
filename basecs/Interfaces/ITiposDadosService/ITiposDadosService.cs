using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.ITiposDadosService
{
    public interface ITiposDadosService
    {
        #region FIND BY ID
        Task<TipoDado> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<TipoDado>> ReturnListWithParametersPaginated(int? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<TipoDado>> ReturnListWithParameters(int? id, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<TipoDado> Insert(TipoDado model);
        #endregion

        #region UPDATE
        Task<TipoDado> Update(TipoDado model);
        #endregion        

        #region DELETE
        Task<TipoDado> Delete(int id);
        #endregion
    }
}
