using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IPagamentosService
{
    public interface IPagamentosService
    {
        #region FIND BY ID
        Task<Pagamento> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<Pagamento>> ReturnListWithParametersPaginated(int? id, int? lancamentoId, string codigoPagamento, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<Pagamento>> ReturnListWithParameters(int? id, int? lancamentoId, string codigoPagamento, bool? ativo);
        #endregion

        #region INSERT
        Task<Pagamento> Insert(Pagamento model);
        #endregion

        #region UPDATE
        Task<Pagamento> Update(Pagamento model);
        #endregion        

        #region DELETE
        Task<Pagamento> Delete(int id);
        #endregion
    }
}
