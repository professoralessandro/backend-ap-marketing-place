

using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IAvaliacoesVendedoresService
{
    public interface IAvaliacoesVendedoresService
    {
        #region FIND BY ID
        Task<AvaliacaoVendedor> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<AvaliacaoVendedor>> ReturnListWithParametersPaginated(int? id, int? telefoneId, int? usuarioId, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<AvaliacaoVendedor>> ReturnListWithParameters(int? id, int? telefoneId, int? usuarioId);
        #endregion

        #region INSERT
        Task<AvaliacaoVendedor> Insert(AvaliacaoVendedor model);
        #endregion

        #region UPDATE
        Task<AvaliacaoVendedor> Update(AvaliacaoVendedor model);
        #endregion        

        #region DELETE
        Task<AvaliacaoVendedor> Delete(int id);
        #endregion
    }
}
