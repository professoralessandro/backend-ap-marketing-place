using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.ITiposNotasFiscaisService
{
    public interface ITiposNotasFiscaisService
    {
        #region FIND BY ID
        Task<TipoNotaFiscal> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<TipoNotaFiscal>> ReturnListWithParametersPaginated(int? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<TipoNotaFiscal>> ReturnListWithParameters(int? id, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<TipoNotaFiscal> Insert(TipoNotaFiscal model);
        #endregion

        #region UPDATE
        Task<TipoNotaFiscal> Update(TipoNotaFiscal model);
        #endregion        

        #region DELETE SERVIÇO DE DELETE
        Task<TipoNotaFiscal> Delete(int id);
        #endregion
    }
}
