

using basecs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace basecs.Interfaces.IFormasPagamentosService
{
    public interface IFormasPagamentosService
    {
        #region FIND BY ID
        Task<FormaPagamento> FindById(int id);
        #endregion

        #region RETURN LIST WITH PARAMETERS PAGINATED
        Task<List<FormaPagamento>> ReturnListWithParametersPaginated(int? id, string descricao, bool? ativo, int? pageNumber, int? rowspPage);
        #endregion

        #region RETURN LIST WITH PARAMETERS
        Task<List<FormaPagamento>> ReturnListWithParameters(int? id, string descricao, bool? ativo);
        #endregion

        #region INSERT
        Task<FormaPagamento> Insert(FormaPagamento model);
        #endregion

        #region UPDATE
        Task<FormaPagamento> Update(FormaPagamento model);
        #endregion        

        #region DELETE
        Task<FormaPagamento> Delete(int id);
        #endregion
    }
}
