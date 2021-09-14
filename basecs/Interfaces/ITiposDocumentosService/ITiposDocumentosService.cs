using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.ITiposDocumentosService
{
    public interface ITiposDocumentosService
    {
        #region FIND BY ID
        Task<TipoDocumento> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<TipoDocumento>> ReturnListWithParametersPaginated(int? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<TipoDocumento>> ReturnListWithParameters(int? id, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<TipoDocumento> Insert(TipoDocumento model);
        #endregion

        #region UPDATE
        Task<TipoDocumento> Update(TipoDocumento model);
        #endregion        

        #region DELETE SERVIÇO DE DELETE COMENTADO
        Task<TipoDocumento> Delete(int id);
        #endregion
    }
}
