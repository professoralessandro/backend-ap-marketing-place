using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.ITiposEmailsService
{
    public interface ITiposEmailsService
    {
        #region FIND BY ID
        Task<TipoEmail> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<TipoEmail>> ReturnListWithParametersPaginated(int? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<TipoEmail>> ReturnListWithParameters(int? id, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<TipoEmail> Insert(TipoEmail model);
        #endregion

        #region UPDATE
        Task<TipoEmail> Update(TipoEmail model);
        #endregion        

        #region DELETE
        Task<TipoEmail> Delete(int id);
        #endregion
    }
}
